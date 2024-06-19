using Catalog.API.Catalog.Products.Queries.GetProducts;
using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace Catalog.API.Unit.Tests.Handle
{

    public class GetProductsHandlerTest
    {
        [Fact]
        public async Task It_Should_Return_List_Products()
        {

            var products = new List<Product>
            {
                new Product(Guid.NewGuid(),"Product 1" ),
                new Product(Guid.NewGuid(),"Product 2" ),
            };

            var productContextMock = new Mock<ProductContext>();
            productContextMock.Setup<DbSet<Product>>(x => x.Products)
                .ReturnsDbSet(products);

            var handler = new GetProductsHandler(productContextMock.Object);
            var query = new GetProductsQuery();

            var result = await handler.Handle(query, new CancellationToken());

            Assert.NotNull(result);
        }
    }
}
