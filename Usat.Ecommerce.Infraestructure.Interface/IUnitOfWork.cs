using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usat.Ecommerce.Infraestructure.Interface
{
    public interface IUnitOfWork
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
    }
}
