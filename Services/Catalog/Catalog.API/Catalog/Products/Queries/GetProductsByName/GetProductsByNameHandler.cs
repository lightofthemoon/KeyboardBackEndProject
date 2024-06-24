using BuildingBlocks.CQRS;
using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Catalog.Products.Queries.GetProductsByName;

public record GetProductsByNameQuery(string Name) : IQuery<GetProductsByNameResult>;

public record GetProductsByNameResult(IEnumerable<Product> Products);

public class GetProductsByNameHandler : IQueryHandler<GetProductsByNameQuery, GetProductsByNameResult>
{
    private readonly CatalogContext _context;
    public GetProductsByNameHandler(CatalogContext context)
    {
        _context = context;
    }
    public async Task<GetProductsByNameResult> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.Where(x => x.ProductName.Contains(request.Name)).ToListAsync();

        return new GetProductsByNameResult(products);
    }
}