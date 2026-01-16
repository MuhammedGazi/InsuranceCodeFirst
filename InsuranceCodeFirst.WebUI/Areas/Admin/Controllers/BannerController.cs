using InsuranceCodeFirst.Business.Services.BannerServices;
using InsuranceCodeFirst.DTO.DTOs.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController(IBannerService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _service.TGetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto dto)
        {
            await _service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _service.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto dto)
        {
            await _service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
