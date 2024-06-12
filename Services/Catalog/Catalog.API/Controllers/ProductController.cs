using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _productContext;
        private readonly CategoryContext _categoryContext;
        private readonly BrandContext _brandContext;

        public ProductController(ProductContext productContext, CategoryContext categoryContext, BrandContext brandContext)
        {
            _productContext = productContext;
            _categoryContext = categoryContext;
            _brandContext = brandContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productContext.Products.ToListAsync();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(Guid id)
        {
            var product = await _productContext.Products.FindAsync(id);

            if(product == null)
            {
                return NotFound("Product not Found");
            }
            return Ok(product);
        }

        [HttpPost]  
        public async Task<ActionResult<Product>> CreateProduct(CreateProductDTO createProductDTO)
        {

            var product = new Product(
                createProductDTO.ProductName,
                createProductDTO.Quantity,
                createProductDTO.Price,
                createProductDTO.Unit,
                createProductDTO.Description,
                createProductDTO.DisplayUrl,
                createProductDTO.CategoryId,
                createProductDTO.BrandId
                );

            await _productContext.Products.AddAsync(product);

            await _productContext.SaveChangesAsync();

            return Ok(product); 
        }
    }
}
