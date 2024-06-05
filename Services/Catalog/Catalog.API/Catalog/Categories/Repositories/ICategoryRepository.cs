using Catalog.API.Models;

namespace Catalog.API.Catalog.Categories.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task DeleteAsync(Guid categoryId);
        Task<Category> GetByIdAsync(Guid categoryId);
        Task<List<Category>> GetAllAsync();

    }
}
