using InsuranceCodeFirst.Business.Services.HuggingFaceServices;
using InsuranceCodeFirst.Business.Services.TavilyServices;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceCodeFirst.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServiceExt(this IServiceCollection services)
        {
            services.Scan(opt =>
                          opt.FromAssemblyOf<BusinessAssembly>()
                          .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
                          .AsImplementedInterfaces()
                          .WithScopedLifetime());

            services.AddHttpClient<ITavilyServices, TavilyServices>();
            services.AddHttpClient<IHuggingFaceService, HuggingFaceService>();
            return services;
        }
    }
}
