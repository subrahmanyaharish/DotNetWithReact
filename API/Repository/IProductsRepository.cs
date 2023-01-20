using API.Entity;

namespace API.Repository
{
    public interface IProductsRepository: IGenericRepository<Product> 
    {
        Task<Product> UpdateProductAsync(Product product);
    }
}
