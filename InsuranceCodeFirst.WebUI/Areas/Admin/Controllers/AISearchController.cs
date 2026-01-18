using InsuranceCodeFirst.Business.Services.TavilyServices;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AISearchController(ITavilyServices _tavilyService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Json(new { success = false, message = "Soru boş olamaz." });

            try
            {
                var result = await _tavilyService.GetSearchQueryResultAsync(query);
                return Json(new { success = true, data = result });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "AI servis bağlantı hatası." });
            }
        }
    }
}
