using DataPorter.Entity;

namespace DataPorter.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IGenericRepository<Customer> Customers { get; }
        public IGenericRepository<Company> Companies { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Customers = new GenericRepository<Customer>(context);
            Companies = new GenericRepository<Company>(context);
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
