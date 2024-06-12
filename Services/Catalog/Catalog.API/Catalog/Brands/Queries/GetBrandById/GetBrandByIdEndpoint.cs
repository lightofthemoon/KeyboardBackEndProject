using Carter;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.Brands.Queries.GetBrandById;

public record GetBrandByIdRequest(Guid Id);

public record GetBrandByIdResponse(Brand Brand);

public class GetBrandByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/cqrs/brand/{id}", 
            async([AsParameters] GetBrandByIdRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetBrandByIdQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetBrandByIdResponse>();

                return Results.Ok(response.Brand);
            });
    }
}