namespace DataPorter.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(string id);
        void Delete(T entity);
    }
}
