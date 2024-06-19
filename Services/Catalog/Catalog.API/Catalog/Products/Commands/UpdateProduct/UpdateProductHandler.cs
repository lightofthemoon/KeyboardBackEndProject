using Catalog.API.Data;
using Catalog.API.DTOs;

namespace Catalog.API.Catalog.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, UpdateProductDTO updateProductDTO) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool isSuccess);
    public class UpdateProductHandler : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly ProductContext _context;
        public UpdateProductHandler(ProductContext context)
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
            product.ProductName = request.updateProductDTO.ProductName;
            product.Quantity = request.updateProductDTO.Quantity;
            product.Price = request.updateProductDTO.Price;
            product.Unit = request.updateProductDTO.Unit;
            product.Description = request.updateProductDTO.Description;
            product.DisplayUrl = request.updateProductDTO.DisplayUrl;
            product.CategoryId = request.updateProductDTO.CategoryId;
            product.BrandId = request.updateProductDTO.BrandId;

            await _context.SaveChangesAsync();
            return new UpdateProductResult(true);
        }
    }
}
