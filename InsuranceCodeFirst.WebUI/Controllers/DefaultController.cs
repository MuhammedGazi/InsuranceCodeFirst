using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
