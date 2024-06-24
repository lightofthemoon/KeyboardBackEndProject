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
        private readonly CatalogContext _productContext;

        public ProductController(CatalogContext productContext)
        {
            _productContext = productContext;
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
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByName(
            [FromQuery(Name = "Name")] string Name)
        {
            var products = await _productContext.Products.Where(x => x.ProductName.Contains(Name)).ToListAsync();

            return Ok(products);
        }
        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(
            [FromQuery(Name = "category")] Guid Category)
        {
            var products = await _productContext.Products.Where(x => x.CategoryId == Category).ToListAsync();

            return Ok(products);
        }

        [HttpGet("brand")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByBrand(
            [FromQuery(Name = "brand")] Guid Brand)
        {
            var products = await _productContext.Products.Where(x => x.BrandId == Brand).ToListAsync();

            return Ok(products);
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
        //[HttpPut("{id}")]
        //public async Task<ActionResult<bool>> UpdateProduct(Guid Id, UpdateProductDTO updateProductDTO)
        //{
        //    var product = await _productContext.Products.FirstOrDefaultAsync(x => x.ProductId == Id);
        //    if(product == null)
        //    {
        //        // return NotFound();
        //    }
        //    product.ProductName = updateProductDTO.ProductName;
        //    product.Quantity = updateProductDTO.Quantity;
        //    product.Price = updateProductDTO.Price;
        //    product.Unit = updateProductDTO.Unit;
        //    product.Description = updateProductDTO.Description;
        //    product.DisplayUrl = updateProductDTO.DisplayUrl;
        //    product.CategoryId = updateProductDTO.CategoryId;
        //    product.BrandId = updateProductDTO.BrandId;

        //    _productContext.Products.Update(product);

        //    var result = await _productContext.SaveChangesAsync() > 0;
        //    if(result) return Ok(true);

        //    return BadRequest("Problem saving changes");
        //}
    }
}
