using InsuranceCodeFirst.Business.Services.CategoryServices;
using InsuranceCodeFirst.DTO.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Controllers
{
    public class CategoryController(ICategoryService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var category = await service.TGetAllAsync();
            return View(category);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            await service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await service.TGetByIdAsync(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            await service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
