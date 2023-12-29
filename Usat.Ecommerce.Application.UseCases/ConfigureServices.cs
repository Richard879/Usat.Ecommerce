using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usat.Ecommerce.Application.Interface.UseCases;
using Usat.Ecommerce.Application.UseCases.Customers;
using Usat.Ecommerce.Application.UseCases.Users;

namespace Usat.Ecommerce.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();

            return services;
        }
    }
}
