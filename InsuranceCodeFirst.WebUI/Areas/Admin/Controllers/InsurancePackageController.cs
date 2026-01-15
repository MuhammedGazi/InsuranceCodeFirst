using InsuranceCodeFirst.Business.Services.CategoryServices;
using InsuranceCodeFirst.Business.Services.InsurancePackageServices;
using InsuranceCodeFirst.DTO.DTOs.InsuranceDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InsurancePackageController(IInsurancePackageService _service, ICategoryService _categoryService) : Controller
    {
        public async Task GetCategories()
        {
            var categories = await _categoryService.TGetAllAsync();
            ViewBag.Categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Value = category.CategoryId.ToString(),
                                      Text = category.CategoryName
                                  }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var values = await _service.TGetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateInsurancePackage()
        {
            await GetCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsurancePackage(CreateInsurancePackageDto dto)
        {
            await _service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateInsurancePackage(int id)
        {
            await GetCategories();
            var value = await _service.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInsurancePackage(UpdateInsurancePackageDto dto)
        {
            await _service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteInsurancePackage(int id)
        {
            await _service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
