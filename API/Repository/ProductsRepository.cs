using API.Data;
using API.Entity;

namespace API.Repository
{
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        private readonly StoreContext storeContext;

        public ProductsRepository(StoreContext storeContext) : base(storeContext)
        {
            this.storeContext = storeContext;
        }
    }
}
