using BuildingBlocks.CQRS;
using Catalog.API.Data;
using Catalog.API.Models;

namespace Catalog.API.Catalog.Brands.Queries.GetBrandById;

public record GetBrandByIdQuery(Guid Id) : IQuery<GetBrandByIdResult>;

public record GetBrandByIdResult(Brand Brand);

public class GetBrandByIdHandler : IQueryHandler<GetBrandByIdQuery, GetBrandByIdResult>
{
    private BrandContext _context;
    public GetBrandByIdHandler(BrandContext context)
    {
        _context = context;
    }
    public async Task<GetBrandByIdResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _context.Brand.FindAsync(request.Id);

        return new GetBrandByIdResult(brand);
    }
}