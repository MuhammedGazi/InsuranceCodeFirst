using InsuranceCodeFirst.Business.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultTestimonialComponentPartial(ITestimonialService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonial = await service.TGetAllAsync();
            return View(testimonial);
        }
    }
}
