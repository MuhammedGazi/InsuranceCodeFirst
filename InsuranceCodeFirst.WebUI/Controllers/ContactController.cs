using InsuranceCodeFirst.Business.Services.ContactServices;
using InsuranceCodeFirst.DTO.DTOs.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Controllers
{
    public class ContactController(IContactService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto dto)
        {
            await _service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }

}
