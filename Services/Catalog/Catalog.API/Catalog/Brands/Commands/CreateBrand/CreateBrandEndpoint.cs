using Carter;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.Brands.Commands.CreateBrand;

public record CreateBrandRequest(string BrandName);

public record CreateBrandResponse(Brand Brand);

public class CreateBrandEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/cqrs/brand", async (CreateBrandRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateBrandCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateBrandResponse>();

            return new CreateBrandResponse(response.Brand);
        });
    }
}
