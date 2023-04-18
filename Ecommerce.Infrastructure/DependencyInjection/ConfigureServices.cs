using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Common;
using Ecommerce.Infrastructure.Persistence.context;
using Ecommerce.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Entity Framework
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.EnableDetailedErrors();

                options.UseSqlServer(configuration.GetConnectionString("EcommerceConnection"),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);

                        sqlOptions.EnableRetryOnFailure(
                            10,
                            TimeSpan.FromSeconds(30),
                            null);
                    });
            }, ServiceLifetime.Scoped, ServiceLifetime.Singleton);

            //=========== Add services ==================================

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
