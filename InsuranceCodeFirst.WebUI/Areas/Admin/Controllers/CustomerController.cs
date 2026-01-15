using InsuranceCodeFirst.Business.Services.CustomerServices;
using InsuranceCodeFirst.DTO.DTOs.CustomerDtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController(ICustomerService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var customer = await service.TGetAllAsync();
            return View(customer);
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto dto)
        {
            await service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var customer = await service.TGetByIdAsync(id);
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto dto)
        {
            await service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
