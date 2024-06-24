using BuildingBlocks.CQRS;
using Catalog.API.Data;
using Catalog.API.Models;

namespace Catalog.API.Catalog.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

public class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    private readonly CatalogContext _context;
    public GetProductByIdHandler(CatalogContext context)
    {
        _context = context;
    }
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);

        if (product == null)
        {
            //throw NotFoundException();
        }
        return new GetProductByIdResult(product);
    }
}