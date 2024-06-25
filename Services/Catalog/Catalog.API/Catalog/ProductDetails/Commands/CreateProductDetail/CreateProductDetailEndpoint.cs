using Carter;
using Catalog.API.DTOs;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.ProductDetails.Commands.CreateProductDetail;

public record CreateProductDetailRequest(CreateProductDetailDTO CreateProductDetailDTO);
public record CreateProductDetailResponse(ProductDetail ProductDetail);

public class CreateProductDetailEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/cqrs/product/detail", 
            async (CreateProductDetailRequest request, ISender sender) =>
        {
            //var command = request.Adapt<CreateProductDetailCommand>();

            var result = await sender.Send(new CreateProductDetailCommand(request.CreateProductDetailDTO));

            var response = result.Adapt<CreateProductDetailResponse>();

            return Results.Ok(response.ProductDetail);
        });
    }
}
