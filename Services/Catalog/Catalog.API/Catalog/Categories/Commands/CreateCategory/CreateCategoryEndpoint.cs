using Catalog.API.Models;
using Carter;
using MediatR;
using Mapster;

namespace Catalog.API.Catalog.Categories.Commands.CreateCategory;

public record CreateCategoryRequest(string CategoryName);

public record CreateCategoryResponse(Category Category);

public class CreateCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/cqrs/category",
            async (CreateCategoryRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateCategoryCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateCategoryResponse>();

                return Results.Ok(response.Category);
            })
            .WithName("CreateCategory")
            .Produces<CreateCategoryResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Cateogory")
            .WithDescription("Create Category");
    }
}
