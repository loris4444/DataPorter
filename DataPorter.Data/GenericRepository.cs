using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataPorter.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = _dbSet;
            if (include != null)
            {
                return await include(_dbSet).ToListAsync();
            }
            return await query.ToListAsync();
        }
        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);
        public async Task<T?> GetByIdAsync(string id)
            => await _dbSet.FindAsync(id);

        public void Delete(T entity)
            => _dbSet.Remove(entity);
    }
}
