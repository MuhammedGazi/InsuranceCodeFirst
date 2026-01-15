using InsuranceCodeFirst.Business.Services.CustomerServices;
using InsuranceCodeFirst.Business.Services.InsurancePackageServices;
using InsuranceCodeFirst.Business.Services.PolicyServices;
using InsuranceCodeFirst.DTO.DTOs.PolicyDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceCodeFirst.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PolicyController(IPolicyService _service,
                                  ICustomerService customerService,
                                  IInsurancePackageService ınsurancePackageService) : Controller
    {
        public async Task GetCustomerAsync()
        {
            var customers = await customerService.TGetAllAsync();
            ViewBag.Customers = (from customer in customers
                                 select new SelectListItem
                                 {
                                     Value = customer.CustomerId.ToString(),
                                     Text = customer.FirstName + " " + customer.LastName
                                 }).ToList();
        }
        public async Task GetInsuraPackageAsync()
        {
            var ınsuraPackage = await ınsurancePackageService.TGetAllAsync();
            ViewBag.InsurancePackages = (from package in ınsuraPackage
                                         select new SelectListItem
                                         {
                                             Value = package.InsurancePackageId.ToString(),
                                             Text = package.InsurancePackageName
                                         }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var policy = await _service.TGetAllAsync();
            return View(policy);
        }

        [HttpGet]
        public async Task<IActionResult> CreatePolicy()
        {
            await GetCustomerAsync();
            await GetInsuraPackageAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePolicy(CreatePolicyDto dto)
        {
            await _service.TCreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePolicy(int id)
        {
            await GetCustomerAsync();
            await GetInsuraPackageAsync();
            var policy = await _service.TGetByIdAsync(id);
            return View(policy);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePolicy(UpdatePolicyDto dto)
        {
            await _service.TUpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeletePolicy(int id)
        {
            await _service.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
