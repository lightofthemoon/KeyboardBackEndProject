using BuildingBlocks.CQRS;
using Catalog.API.Data;
using Catalog.API.Models;

namespace Catalog.API.Catalog.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IQuery<GetCategoryByIdResult>;

public record GetCategoryByIdResult(Category Category);

public class GetCategoryByIdHandler : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdResult>
{
    private readonly CatalogContext _context;
    public GetCategoryByIdHandler(CatalogContext context)
    {
        _context = context;
    }
    public async Task<GetCategoryByIdResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Category.FindAsync(request.Id);

        return new GetCategoryByIdResult(category);
    }
}
