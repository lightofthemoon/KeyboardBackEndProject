using BuildingBlocks.CQRS;
using Catalog.API.Data;
using Catalog.API.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Catalog.API.Catalog.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery() : IQuery<GetAllCategoriesResult>;

public record GetAllCategoriesResult(List<Category> Categories);


public class GetAllCategoriesHandler : IQueryHandler<GetAllCategoriesQuery, GetAllCategoriesResult>
{
    private readonly CategoryContext _context;
    public GetAllCategoriesHandler(CategoryContext context)
    {
        _context = context;
    }

    public async Task<GetAllCategoriesResult> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = _context.Category.ToListAsync().Adapt<GetAllCategoriesResult>();

        return categories;
    }
}