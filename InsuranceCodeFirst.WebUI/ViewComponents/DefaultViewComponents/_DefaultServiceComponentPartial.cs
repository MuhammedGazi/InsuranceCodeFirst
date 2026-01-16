using InsuranceCodeFirst.Business.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultServiceComponentPartial(IServiceService _service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _service.TGetAllAsync();
            return View(services);
        }
    }
}
