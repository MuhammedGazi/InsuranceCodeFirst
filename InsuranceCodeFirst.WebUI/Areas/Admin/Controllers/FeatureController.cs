using InsuranceCodeFirst.Business.Services.FeatureServices;
using InsuranceCodeFirst.DTO.DTOs.FeatureDtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController(IFeatureService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _service.TGetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            await _service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _service.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            await _service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
