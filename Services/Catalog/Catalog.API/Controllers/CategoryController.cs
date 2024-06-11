using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Models;
using MapsterMapper;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("/api/v1/category")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryContext _context;

        public CategoryController(CategoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _context.Category.ToListAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var category = new Category(createCategoryDTO.CategoryName);

            category.CategoryId = Guid.NewGuid();

            await _context.Category.AddAsync(category);

            //var newCategory = _mapper.Map<Category>(category);

            await _context.SaveChangesAsync();

            return Ok();
                
        }
    }
}
