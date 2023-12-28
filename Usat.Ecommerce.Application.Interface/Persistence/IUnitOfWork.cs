namespace Usat.Ecommerce.Application.Interface.Persistence
{
    public interface IUnitOfWork
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
    }
}
