using Carter;
using Catalog.API.Catalog.Products.Queries.GetProductsByName;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.Products.Queries.GetProducts;

public record GetProductsRequest();

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapGet("/api/v1/cqrs/product", 
            async ([AsParameters] GetProductsRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());

                //var response = result.Adapt<GetProductsResponse>();

                return new GetProductsResponse(result.Products);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products"); 
    }
}
