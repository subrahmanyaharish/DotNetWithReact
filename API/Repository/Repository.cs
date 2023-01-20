using API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Repository
{
    public class Repository<T>: IGenericRepository<T> where T : class
    {
        private readonly StoreContext _storeContext;
        internal DbSet<T> _dbSet;

        public Repository(StoreContext storeContext)
        {
            _storeContext = storeContext;
            _dbSet = _storeContext.Set<T>();            
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
            if(filter != null) 
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetItem(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
            if(filter!= null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _storeContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            _dbSet.Remove(item);
            await _storeContext.SaveChangesAsync();
        }

    }
}
