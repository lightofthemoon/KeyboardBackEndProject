using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Models;

namespace Catalog.API.Catalog.Products.Commands.CreateProduct;

public record CreateProductCommand(CreateProductDTO CreateProductDto) : ICommand<CreateProductResult>;

public record CreateProductResult(Product Product);
public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>

{
    private readonly CatalogContext _context;
    public CreateProductHandler(CatalogContext context)
    {
        _context = context;
    }
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
                request.CreateProductDto.ProductName,
                request.CreateProductDto.Quantity,
                request.CreateProductDto.Price,
                request.CreateProductDto.Unit,
                request.CreateProductDto.Description,
                request.CreateProductDto.DisplayUrl,
                request.CreateProductDto.CategoryId,
                request.CreateProductDto.BrandId
                );

        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();

        return new CreateProductResult(product);
    }
}