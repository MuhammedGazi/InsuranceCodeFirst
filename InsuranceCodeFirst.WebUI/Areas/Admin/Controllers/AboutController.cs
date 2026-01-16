using InsuranceCodeFirst.Business.Services.AboutServices;
using InsuranceCodeFirst.DTO.DTOs.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController(IAboutService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _service.TGetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            await _service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _service.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            await _service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
