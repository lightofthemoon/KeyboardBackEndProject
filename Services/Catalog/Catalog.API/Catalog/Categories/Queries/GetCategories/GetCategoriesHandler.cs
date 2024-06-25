using BuildingBlocks.CQRS;
using Catalog.API.Data;
using Catalog.API.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Catalog.API.Catalog.Categories.Queries.GetAllCategories;

public record GetCategoriesQuery(int? PageNumber, int? PageSize) : IQuery<GetCategoriesResult>;

public record GetCategoriesResult(IEnumerable<Category> Categories);

public class GetCategoriesHandler : IQueryHandler<GetCategoriesQuery, GetCategoriesResult>
{
    private readonly CatalogContext _context;
    public GetCategoriesHandler(CatalogContext context)
    {
        _context = context;
    }

    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories.ToListAsync();

        return new GetCategoriesResult(categories);
    }
}