using InsuranceCodeFirst.Business.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeatureComponentPartial(IFeatureService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var feature = await service.TGetAllAsync();
            return View(feature);
        }
    }
}
