using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public class BrandDbInnitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<BrandContext>());
        }

        private static async void SeedData(BrandContext context)
        {
            if(context == null)
            {
                Console.WriteLine("Context is null");
                return;
            }
            context.Database.Migrate();

            if (context.Brand.Any())
            {
                Console.WriteLine("Have data, don't need to migrate");
                return;
            }

            var brands = new List<Brand>()
            {
                new Brand(Guid.NewGuid(), "Brand 1"),
                new Brand(Guid.NewGuid(), "Brand 2"),
                new Brand(Guid.NewGuid(), "Brand 3"),
                new Brand(Guid.NewGuid(), "Brand 4"),
                new Brand(Guid.NewGuid(), "Brand 5"),
            };
            context.AddRange(brands);
            await context.SaveChangesAsync();
        }
    }
}
