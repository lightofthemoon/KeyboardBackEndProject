using Carter;
using Catalog.API.Catalog.Products.Queries.GetProductsByName;
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
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}