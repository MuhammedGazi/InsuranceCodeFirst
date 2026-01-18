using InsuranceCodeFirst.Business.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsController(IContactService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var contact = await service.TGetAllAsync();
            return View(contact);
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
