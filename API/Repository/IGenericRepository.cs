using System.Linq.Expressions;

namespace API.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetItem(Expression<Func<T, bool>> filter = null);
        Task AddAsync(T item);
        Task DeleteAsync(T item);

    }
}
