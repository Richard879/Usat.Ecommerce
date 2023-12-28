using Usat.Ecommerce.Domain.Entity;

namespace Usat.Ecommerce.Application.Interface.Persistence
{
    public interface IUsersRepository
    {
        User Authenticate(string username, string password);
    }
}
