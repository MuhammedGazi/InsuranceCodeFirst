using InsuranceCodeFirst.Business.Services.FAQServices;
using InsuranceCodeFirst.DTO.DTOs.FAQDtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FAQController(IFAQService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _service.TGetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFAQ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFAQ(CreateFAQDto dto)
        {
            await _service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFAQ(int id)
        {
            var value = await _service.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFAQ(UpdateFAQDto dto)
        {
            await _service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteFAQ(int id)
        {
            await _service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

