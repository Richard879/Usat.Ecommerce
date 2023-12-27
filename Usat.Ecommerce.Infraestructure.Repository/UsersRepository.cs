using Dapper;
using System.Data;
using Usat.Ecommerce.Domain.Entity;
using Usat.Ecommerce.Infraestructure.Data;
using Usat.Ecommerce.Infraestructure.Interface;

namespace Usat.Ecommerce.Infraestructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperContext _context;

        public UsersRepository(DapperContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
