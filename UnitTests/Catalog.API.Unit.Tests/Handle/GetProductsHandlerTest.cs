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

            var productContextMock = new Mock<CatalogContext>();
            productContextMock.Setup<DbSet<Product>>(x => x.Products)
                .ReturnsDbSet(products);

            var handler = new GetProductsHandler(productContextMock.Object);
            var query = new GetProductsQuery();

            var result = await handler.Handle(query, new CancellationToken());

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Handle_ShouldReturnGetProductsResult()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product(Guid.NewGuid(),"Product 1" ),
                new Product(Guid.NewGuid(),"Product 2" ),
            };

            var mockContext = new Mock<CatalogContext>();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.AsQueryable().Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.AsQueryable().Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.AsQueryable().ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.AsQueryable().GetEnumerator());
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var handler = new GetProductsHandler(mockContext.Object);

            // Act
            var result = await handler.Handle(new GetProductsQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Products.Count());
            Assert.Equal(products.Select(p => p.ProductName), result.Products.Select(p => p.ProductName));
        }
    }
}
