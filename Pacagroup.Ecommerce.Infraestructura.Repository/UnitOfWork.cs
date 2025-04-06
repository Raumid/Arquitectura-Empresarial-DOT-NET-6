using Pacagroup.Ecommerce.Infraestructura.Interface;

namespace Pacagroup.Ecommerce.Infraestructura.Repository
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
