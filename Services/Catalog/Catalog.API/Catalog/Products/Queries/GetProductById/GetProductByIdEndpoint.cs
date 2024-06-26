using Carter;
using Catalog.API.Catalog.Products.Queries.GetProductsByName;
using Catalog.API.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            if (result == null) return Results.NotFound("ProductNotFound");
            return Results.Ok(result.Product);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}