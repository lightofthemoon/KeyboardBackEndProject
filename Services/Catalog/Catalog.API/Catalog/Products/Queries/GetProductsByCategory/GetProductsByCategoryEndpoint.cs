using Carter;
using Catalog.API.Catalog.Products.Commands.CreateProduct;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Catalog.Products.Queries.GetProductsByCategory;

public record GetProductsByCategoryRequest(Guid Id);

public record GetProductsByCategoryResponse(IEnumerable<Product> Products);
public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/cqrs/product/category/{id}", 
            async ([AsParameters] GetProductsByCategoryRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsByCategoryQuery(request.Id));

            return new GetProductsByCategoryResponse(result.Products);
        })
        .WithName("GetProductsByCategory")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products By Category")
        .WithDescription("Get Products By Category"); 
    }
}