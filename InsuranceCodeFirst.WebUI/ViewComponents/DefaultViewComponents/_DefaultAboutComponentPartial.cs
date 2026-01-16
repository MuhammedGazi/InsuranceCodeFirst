using InsuranceCodeFirst.Business.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutComponentPartial(IAboutService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await service.TGetAllAsync();
            var about = values.FirstOrDefault();
            return View(about);
        }
    }
}
