using Catalog.API.Data;
using Catalog.API.DTOs;

namespace Catalog.API.Catalog.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, UpdateProductDTO UpdateProductDTO) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool isSuccess);
    public class UpdateProductHandler : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly CatalogContext _context;
        public UpdateProductHandler(CatalogContext context)
        {
            _context = context;
        }
        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
            {
                //return NotFound();
            }
            product.ProductName = request.UpdateProductDTO.ProductName;
            product.Quantity = request.UpdateProductDTO.Quantity;
            product.Price = request.UpdateProductDTO.Price;
            product.Unit = request.UpdateProductDTO.Unit;
            product.Description = request.UpdateProductDTO.Description;
            product.DisplayUrl = request.UpdateProductDTO.DisplayUrl;
            product.CategoryId = request.UpdateProductDTO.CategoryId;
            product.BrandId = request.UpdateProductDTO.BrandId;

            await _context.SaveChangesAsync();
            return new UpdateProductResult(true);
        }
    }
}
