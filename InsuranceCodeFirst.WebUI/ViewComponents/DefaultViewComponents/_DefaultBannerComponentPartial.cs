using InsuranceCodeFirst.Business.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCodeFirst.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBannerComponentPartial(IBannerService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners = await service.TGetAllAsync();
            var banner = banners.FirstOrDefault();
            return View(banner);
        }
    }
}
