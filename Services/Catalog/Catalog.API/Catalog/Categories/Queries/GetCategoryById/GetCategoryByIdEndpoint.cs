using BuildingBlocks.CQRS;
using Carter;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.Categories.Queries.GetCategoryById;

public record GetCategoryByIdRequest(Guid Id);

public record GetCategoryByIdResponse(Category Category);

public class GetCategoryByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/cqrs/category/{id}",
            async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetCategoryByIdQuery(id));

                //var response = result.Adapt<GetCategoryByIdResponse>();

                return Results.Ok(result);
            });
    }
}
