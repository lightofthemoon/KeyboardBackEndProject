using BuildingBlocks.CQRS;
using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Catalog.Products.Queries.GetProductsByCategory;

public record GetProductsByCategoryQuery(Guid Id) : IQuery<GetProductsByCategoryResult>;

public record GetProductsByCategoryResult(IEnumerable<Product> Products);


public class GetProductsByCategoryHandler : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    private readonly CatalogContext _context;
    public GetProductsByCategoryHandler(CatalogContext context)
    {
        _context = context;    
    }
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.Where(x => x.CategoryId == request.Id).ToListAsync();

        return new GetProductsByCategoryResult(products);
    }
}