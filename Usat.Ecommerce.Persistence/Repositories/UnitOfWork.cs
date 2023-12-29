﻿using Usat.Ecommerce.Application.Interface.Persistence;

namespace Usat.Ecommerce.Persistence.Repositories
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
            GC.SuppressFinalize(this);
        }
    }
}
