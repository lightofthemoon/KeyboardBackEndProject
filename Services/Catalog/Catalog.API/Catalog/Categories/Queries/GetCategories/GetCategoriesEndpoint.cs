using Carter;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.Categories.Queries.GetAllCategories;

public record GetCategoriesRequest();

public record GetCategoriesResponse(List<Category> Categories);

public class GetCategoriesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/cqrs/category",
            async ([AsParameters] GetCategoriesRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetCategoriesQuery>();

                var result = await sender.Send(query);

                //var response = result.Adapt<GetAllCategoriesResponse>();

                return Results.Ok(result.Categories);
            })
            .WithName("GetCategories")
            .Produces<GetCategoriesResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Cateogories")
            .WithDescription("Get Categories");
    }
}