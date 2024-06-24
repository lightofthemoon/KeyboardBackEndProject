using BuildingBlocks.CQRS;
using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Catalog.Products.Queries.GetProducts;

public record GetProductsQuery() : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);

public class GetProductsHandler : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    private readonly CatalogContext _context;
    public GetProductsHandler(CatalogContext context)
    {
        _context = context;
    }
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.ToListAsync();
        return new GetProductsResult(products);
    }
}
