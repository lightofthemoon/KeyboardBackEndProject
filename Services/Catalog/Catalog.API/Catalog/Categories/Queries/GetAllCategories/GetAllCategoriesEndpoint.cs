using Carter;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.Categories.Queries.GetAllCategories;

public record GetAllCategoriesRequest();

public record GetAllCategoriesResponse(List<Category> Categories);

public class GetAllCategoriesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/cqrs/category",
            async ([AsParameters] GetAllCategoriesRequest request, ISender sender) =>
            {
                var command = request.Adapt<GetAllCategoriesQuery>();

                var result = await sender.Send(command);

                var response = result.Adapt<GetAllCategoriesResponse>();

                return new GetAllCategoriesResponse(response.Categories);
            })
            .WithName("GetCategories")
            .Produces<GetAllCategoriesResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Cateogories")
            .WithDescription("Get Categories");
    }
}