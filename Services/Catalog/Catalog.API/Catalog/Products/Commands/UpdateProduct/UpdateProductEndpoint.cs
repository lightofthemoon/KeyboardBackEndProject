using Carter;
using Catalog.API.DTOs;
using MediatR;

namespace Catalog.API.Catalog.Products.Commands.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, UpdateProductDTO UpdateProductDTO);
    public record UpdateProductResponse(bool isSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/api/v1/cqrs/product/{id}", 
                async (UpdateProductRequest request, ISender sender) =>
            {
                var result = sender.Send(new UpdateProductCommand(request.UpdateProductDTO.Id, request.UpdateProductDTO));

                return new UpdateProductResponse(!result.IsFaulted);
            })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
        }
    }
}
