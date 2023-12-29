using Dapper;
using System.Data;
using Usat.Ecommerce.Application.Interface.Persistence;
using Usat.Ecommerce.Domain.Entity;
using Usat.Ecommerce.Persistence.Context;

namespace Usat.Ecommerce.Persistence.Repositories
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
