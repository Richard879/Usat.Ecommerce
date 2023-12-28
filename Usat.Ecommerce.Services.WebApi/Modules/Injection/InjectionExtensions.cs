using Usat.Ecommerce.Application.Interface.Persistence;
using Usat.Ecommerce.Application.Interface.UseCases;
using Usat.Ecommerce.Application.UseCases;
using Usat.Ecommerce.Persistence.Data;
using Usat.Ecommerce.Persistence.Repository;
using Usat.Ecommerce.Transversal.Common;
using Usat.Ecommerce.Transversal.Logging;

namespace Usat.Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
