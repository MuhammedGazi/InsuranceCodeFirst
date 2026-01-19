using InsuranceCodeFirst.DAL.Context;
using InsuranceCodeFirst.DTO.DTOs.DashboardDtos;
using InsuranceCodeFirst.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController(AppDbContext context) : Controller
    {
        public IActionResult Index()
        {
            var result = new ResultDashboardDto();
            result.CustomerCount = context.Customers.Count();
            result.PolicyActiveCount = context.Policies.Where(x => x.IsActive == true).Count();
            result.PolicyPriceCount = context.Policies.Sum(x => x.Price);
            result.PolicyPriceAvgCount = context.Policies.Average(x => x.Price);
            result.PolicyMostInsurancePackageCount = context.Policies.GroupBy(x => x.InsurancePackage.InsurancePackageName).OrderByDescending(y => y.Count()).Select(g => g.Key).FirstOrDefault();
            result.PolicyCategoryMostPriceCount = context.Policies.GroupBy(x => x.InsurancePackage.Category.CategoryName).OrderByDescending(y => y.Sum(m => m.Price)).Select(g => g.Key).FirstOrDefault();
            result.PolicyFalseAvgCount = context.Policies.Where(m => m.IsActive == false).Count() / context.Policies.Count();
            result.PolicyLoyaltyCustomer = context.Policies.GroupBy(x => x.CustomerId).OrderByDescending(y => y.Count() > 1).Select(g => g.Key).FirstOrDefault();
            result.PolicyEndDate = context.Policies.Where(x => x.EndDate >= DateTime.Today && x.EndDate < DateTime.Today.AddDays(30)).Count();
            result.PolicyMaxPrice = context.Policies.Max(y => y.Price);
            result.PolicyWaitPrice = context.Policies.Where(y => y.IsActive == true).Sum(y => y.Price);
            result.PolicyMinPrice = context.Policies.OrderBy(y => y.Price).Select(y => y.PolicyNumber).FirstOrDefault();
            result.ExpensiveCustomer = context.Policies.OrderByDescending(x => x.Price).Select(x => x.Customer.FirstName).FirstOrDefault();
            result.PotentialCustomerCount = context.Customers.Where(c => !context.Policies.Any(p => p.CustomerId == c.CustomerId)).Count();
            var enCokPoliceOlanGrup = context.Policies.GroupBy(p => p.StartDate.Month).Select(g => new { Month = g.Key, Count = g.Count() }).FirstOrDefault();
            result.MostMonthName = CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat.GetMonthName(enCokPoliceOlanGrup.Month);

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
