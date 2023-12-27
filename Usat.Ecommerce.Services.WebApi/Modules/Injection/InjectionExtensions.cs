using Usat.Ecommerce.Application.Interface;
using Usat.Ecommerce.Application.Main;
using Usat.Ecommerce.Domain.Core;
using Usat.Ecommerce.Domain.Interface;
using Usat.Ecommerce.Infraestructure.Data;
using Usat.Ecommerce.Infraestructure.Interface;
using Usat.Ecommerce.Infraestructure.Repository;

namespace Usat.Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
