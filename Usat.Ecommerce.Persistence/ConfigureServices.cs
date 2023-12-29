using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usat.Ecommerce.Application.Interface.Persistence;
using Usat.Ecommerce.Persistence.Context;
using Usat.Ecommerce.Persistence.Repositories;

namespace Usat.Ecommerce.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
