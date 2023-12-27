using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usat.Ecommerce.Infraestructure.Interface;

namespace Usat.Ecommerce.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepository Customers { get; }
        public IUsersRepository Users { get; }

        public UnitOfWork(ICustomersRepository customers, IUsersRepository users)
        {
            Customers = customers;
            Users = users;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
