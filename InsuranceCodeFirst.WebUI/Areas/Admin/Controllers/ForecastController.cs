using InsuranceCodeFirst.DAL.Context;
using InsuranceCodeFirst.DTO.DTOs.ForecastData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ForecastController : Controller
    {
        private readonly AppDbContext _context;
        private readonly MLContext _mLContext;

        public ForecastController(MLContext mLContext, AppDbContext context)
        {
            _mLContext = mLContext;
            _context = context;
        }

        [HttpGet]
        public IActionResult CityForecast()
        {
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2025, 12, 31);

            var rawData = _context.Policies
                .Include(o => o.Customer)
                .Include(y => y.InsurancePackage)
                .ThenInclude(m => m.Category)
                .Where(x => x.StartDate >= startDate && x.StartDate <= endDate)
                .Select(x => new
                {
                    x.Customer.City,
                    CategoryName = x.InsurancePackage.Category.CategoryName,
                    PackageName = x.InsurancePackage.InsurancePackageName,
                    PackagePrice = x.InsurancePackage.BasePrice,
                    x.StartDate.Year,
                    x.StartDate.Month
                })
                .ToList();

            var groupedData = rawData
                .GroupBy(x => new { x.City, x.CategoryName, x.PackageName, x.Year, x.Month })
                .Select(g => new
                {
                    g.Key.City,
                    g.Key.CategoryName,
                    g.Key.PackageName,
                    AvgPrice = g.Average(p => p.PackagePrice),
                    DateKey = $"{g.Key.Year}-{g.Key.Month:D2}",
                    OrderCount = g.Count()
                })
                .ToList();

            var forecasts = new List<ForecastResultDto>();

            var distinctGroups = groupedData
                .Select(x => new { x.City, x.CategoryName, x.PackageName, x.AvgPrice })
                .Distinct()
                .ToList();

            foreach (var group in distinctGroups)
            {
                var seriesData = groupedData
                    .Where(x => x.City == group.City && x.PackageName == group.PackageName)
                    .OrderBy(x => x.DateKey)
                    .ToList();

                if (seriesData.Count == 0) continue;

                int dataCount = seriesData.Count;

                if (dataCount < 5)
                {
                    var avg = seriesData.Average(s => s.OrderCount);
                    var manualForecast = (int)(avg * 12);

                    forecasts.Add(new ForecastResultDto
                    {
                        City = group.City,
                        Category = group.CategoryName,
                        Package = group.PackageName,
                        ForecastedCount = manualForecast,
                        EstimatedRevenue = manualForecast * group.AvgPrice
                    });
                    continue;
                }

                int windowSize = Math.Max(2, dataCount / 3);

                try
                {
                    var mlInputData = seriesData.Select((x, index) => new CityForecastData
                    {
                        City = x.City,
                        MonthIndex = index + 1,
                        OrderCount = (float)x.OrderCount
                    }).ToList();

                    var dataView = _mLContext.Data.LoadFromEnumerable(mlInputData);

                    var pipeline = _mLContext.Forecasting.ForecastBySsa(
                        outputColumnName: "ForecastedValues",
                        inputColumnName: nameof(CityForecastData.OrderCount),
                        windowSize: windowSize,
                        seriesLength: mlInputData.Count,
                        trainSize: mlInputData.Count,
                        horizon: 12,
                        confidenceLevel: 0.95f
                    );

                    var model = pipeline.Fit(dataView);
                    var engine = model.CreateTimeSeriesEngine<CityForecastData, CityForecastPrediction>(_mLContext);
                    var prediction = engine.Predict();

                    var forecastedTotal = (int)Math.Max(0, prediction.ForecastedValues.Sum());

                    forecasts.Add(new ForecastResultDto
                    {
                        City = group.City,
                        Category = group.CategoryName,
                        Package = group.PackageName,
                        ForecastedCount = forecastedTotal,
                        EstimatedRevenue = forecastedTotal * group.AvgPrice
                    });
                }
                catch (Exception ex)
                {
                    var avg = seriesData.Average(s => s.OrderCount);
                    var manualForecast = (int)(avg * 12);

                    forecasts.Add(new ForecastResultDto
                    {
                        City = group.City,
                        Category = group.CategoryName,
                        Package = group.PackageName,
                        ForecastedCount = manualForecast,
                        EstimatedRevenue = manualForecast * group.AvgPrice
                    });
                }
            }

            // Eğer veritabanında hiç veri yoksa, test için istersen sil
            if (forecasts.Count == 0)
            {
                forecasts.Add(new ForecastResultDto { City = "Test Ankara", Category = "Test Kat", Package = "Test Paket", ForecastedCount = 100, EstimatedRevenue = 50000 });
                forecasts.Add(new ForecastResultDto { City = "Test İstanbul", Category = "Test Kat", Package = "Test Paket", ForecastedCount = 150, EstimatedRevenue = 75000 });
            }

            return View(forecasts);
        }
    }
}
