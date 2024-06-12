using Carter;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.Brands.Queries.GetAllBrands;

public record GetBrandsRequest();

public record GetBrandsResponse(IEnumerable<Brand> Brands);

public class GetBrandsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/cqrs/brand",
            async ([AsParameters] GetBrandsRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetBrandsQuery>();  

            var result = await sender.Send(query);

            //var response = result.Adapt<GetAllBrandResponse>();

            return Results.Ok(result.Adapt<GetBrandsResponse>().Brands);
        })
        .WithName("GetAllBrands")
        .Produces<GetBrandsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get All Brands")
        .WithDescription("Get All Brands"); 
    }
}