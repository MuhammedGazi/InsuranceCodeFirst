using InsuranceCodeFirst.DAL.Context;
using InsuranceCodeFirst.DAL.Repositories.GenericRepositories;
using InsuranceCodeFirst.DAL.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceCodeFirst.DAL.Extensions
{
    public static class RepositoryRegistrations
    {
        public static IServiceCollection AddRepositoriesExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.Scan(opt =>
                          opt.FromAssemblyOf<DataAccessAssembly>()
                          .AddClasses(x => x.Where(t => t.Name.EndsWith("Repository")))
                          .AsImplementedInterfaces()
                          .WithScopedLifetime());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
