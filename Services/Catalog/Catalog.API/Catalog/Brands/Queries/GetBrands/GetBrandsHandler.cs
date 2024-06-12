using BuildingBlocks.CQRS;
using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Catalog.Brands.Queries.GetAllBrands;

public record GetBrandsQuery() : IQuery<GetBrandsResult>;

public record GetBrandsResult(List<Brand> Brands);


public class GetBrandsHandler : IQueryHandler<GetBrandsQuery, GetBrandsResult>
{
    private BrandContext _context;
    public GetBrandsHandler(BrandContext context)
    {
        _context = context;
    }
    public async Task<GetBrandsResult> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _context.Brand.ToListAsync();

        return new GetBrandsResult(brands);
    }
}