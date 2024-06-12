using Carter;
using Catalog.API.DTOs;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Catalog.Products.CreateProduct;


public record CreateProductRequest(CreateBrandDTO CreateProductDto);

public record CreateProductResponse(Product Product);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/cqrs/product", 
            async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Ok(response.Product);
            });
    }
}