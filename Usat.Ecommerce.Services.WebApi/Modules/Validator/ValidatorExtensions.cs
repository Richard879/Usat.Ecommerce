using Usat.Ecommerce.Application.Validator;

namespace Usat.Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UserDtoValidator>();
            return services;
        }
    }
}
