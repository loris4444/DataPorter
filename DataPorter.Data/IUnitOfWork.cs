using DataPorter.Entity;

namespace DataPorter.Data
{
    public interface IUnitOfWork
    {
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Company> Companies { get; }
        Task<int> SaveAsync();
    }
}
