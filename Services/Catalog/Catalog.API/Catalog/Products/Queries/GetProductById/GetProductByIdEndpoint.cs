using Carter;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.Products.Queries.GetProductById;

public record GetProductByIdRequest(Guid Id);

public record GetProductByIdResponse(Product Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/cqrs/product/{id}", async([AsParameters] GetProductByIdRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(request.Id));

            //var response = result.Adapt<GetProductByIdResponse>();

            return new GetProductByIdResponse(result.Product);
        });
    }
}