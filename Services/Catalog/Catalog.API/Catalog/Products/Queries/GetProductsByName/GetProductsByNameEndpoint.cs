using Carter;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Catalog.Products.Queries.GetProductsByName;

public record GetProductsByNameRequest(string Name);

public record GetProductsByNameResponse(IEnumerable<Product> Products);

public class GetProductsByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/cqrs/product/name/{Name}", 
            async ([AsParameters] GetProductsByNameRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsByNameQuery(request.Name));

            return new GetProductsByNameResponse(result.Products);
        });
    }
}
