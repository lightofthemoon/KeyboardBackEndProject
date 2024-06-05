using Catalog.API.Models;

namespace Catalog.API.Catalog.Categories.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GettAllAsync();
        Task<Product> GettByIdAsync(int id);
        Task AddAsync(Product product);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Product product);
    }
}
