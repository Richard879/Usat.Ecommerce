using Usat.Ecommerce.Application.DTO;
using Usat.Ecommerce.Transversal.Common;

namespace Usat.Ecommerce.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UserDto> Authenticate(string username, string password);
    }
}
