using InsuranceCodeFirst.Business.Services.CustomerServices;
using InsuranceCodeFirst.Business.Services.TestimonialServices;
using InsuranceCodeFirst.DTO.DTOs.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(ITestimonialService _service, ICustomerService customerService) : Controller
    {
        public async Task GetCustomer()
        {
            var customers = await customerService.TGetAllAsync();
            ViewBag.Customers = (from customer in customers
                                 select new SelectListItem
                                 {
                                     Value = customer.CustomerId.ToString(),
                                     Text = $"{customer.FirstName} {customer.LastName}"
                                 }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var values = await _service.TGetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTestimonial()
        {
            await GetCustomer();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            await _service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            await GetCustomer();
            var value = await _service.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            await _service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
