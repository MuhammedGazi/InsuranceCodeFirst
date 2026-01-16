using InsuranceCodeFirst.Business.Services.ServiceServices;
using InsuranceCodeFirst.DTO.DTOs.ServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController(IServiceService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _service.TGetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto dto)
        {
            await _service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _service.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
        {
            await _service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
