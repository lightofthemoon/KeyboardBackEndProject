using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Exceptions;
using Catalog.API.Models;

namespace Catalog.API.Catalog.ProductDetails.Commands.CreateProductDetail;

public record CreateProductDetailCommand(CreateProductDetailDTO CreateProductDetailDTO) : ICommand<CreateProductDetailResult>;

public record CreateProductDetailResult(ProductDetail ProductDetail);

public class CreateProductDetailHandler : ICommandHandler<CreateProductDetailCommand, CreateProductDetailResult>
{
    private readonly CatalogContext _context;
    public CreateProductDetailHandler(CatalogContext context)
    {
        _context = context;
    }
    public async Task<CreateProductDetailResult> Handle(CreateProductDetailCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.CreateProductDetailDTO.ProductId, cancellationToken);
        if (product == null)
        {
            throw new ProductNotFoundException(request.CreateProductDetailDTO.ProductId);
        }
        ProductDetail productDetail = new ProductDetail();
        productDetail.Id = Guid.NewGuid();
        productDetail.ProductId = request.CreateProductDetailDTO.ProductId;
        productDetail.Color = request.CreateProductDetailDTO.Color;
        productDetail.Price = request.CreateProductDetailDTO.Price;
        productDetail.Quantity = request.CreateProductDetailDTO.Quantity;
        productDetail.ImageUrl = request.CreateProductDetailDTO.ImageUrl;

        await _context.ProductDetails.AddAsync(productDetail);
        await _context.SaveChangesAsync();

        return new CreateProductDetailResult(productDetail);
    }
}

