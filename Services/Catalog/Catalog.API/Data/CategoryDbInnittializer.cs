
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public class CategoryDbInnittializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<CategoryContext>());
        }

        private static async void SeedData(CategoryContext context)
        {
            context.Database.Migrate();
            
            if(context.Category.Any())
            {
                Console.WriteLine("Have data, don't need to migrate");
                return;
            }

            var categories = new List<Category>()
            {
                new Category(Guid.NewGuid(), "Category 1"),
                new Category(Guid.NewGuid(), "Category 2"),
                new Category(Guid.NewGuid(), "Category 3"),
                new Category(Guid.NewGuid(), "Category 4"),
                new Category(Guid.NewGuid(), "Category 5"),
            };
            context.AddRange(categories);
            await context.SaveChangesAsync(); 
        }
    }
}
