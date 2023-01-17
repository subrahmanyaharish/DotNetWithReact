using API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Repository
{
    public class Repository<T>: IGenericRepository<T> where T : class
    {
        private readonly StoreContext storeContext;
        internal DbSet<T> dbSet;

        public Repository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
            this.dbSet = this.storeContext.Set<T>();            
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null) 
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
    }
}
