using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Controllers
{
    [Route("api/v1/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly CatalogContext _context;

        public BrandController(CatalogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrand()
        {
            var brands = await _context.Brand.ToListAsync();

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetById(Guid Id)
        {
            var brand = await _context.Brand.FindAsync(Id);

            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> CreateBrand([FromBody] CreateBrandDTO createBrandDto)
        {
            var brand = new Brand(Guid.NewGuid(), createBrandDto.BrandName);
            brand.PhoneNumber = createBrandDto.PhoneNumber;
            brand.Email = createBrandDto.Email;

            await _context.Brand.AddAsync(brand);
            await _context.SaveChangesAsync();

            return Ok(brand);
        }
    }
}
