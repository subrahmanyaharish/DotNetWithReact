using API.Data;
using API.Entity;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(StoreContext storeContext, IProductsRepository productsRepository)
        {
            _storeContext = storeContext;
            _productsRepository = productsRepository;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //List<Product> products = await productsRepository.GetAllAsync();
            var products = await _storeContext.Products.ToListAsync();
            return  Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var products = await _storeContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            return Ok(products);
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _storeContext.Products.AddAsync(product);
            await _storeContext.SaveChangesAsync();
            return Ok();
        }

    }
}
