using InsuranceCodeFirst.Business.Services.FAQServices;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFAQComponentPartial(IFAQService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var faq = await service.TGetAllAsync();
            return View(faq);
        }
    }
}
