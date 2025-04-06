namespace Pacagroup.Ecommerce.Infraestructura.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
    }
}
