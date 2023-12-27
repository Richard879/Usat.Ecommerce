using Usat.Ecommerce.Domain.Entity;

namespace Usat.Ecommerce.Infraestructure.Interface
{
    public interface IUsersRepository
    {
        User Authenticate(string username, string password);
    }
}
