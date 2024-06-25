using Catalog.API.Data;
using Catalog.API.Models;
using FluentValidation;
using System.Reflection.Metadata;

namespace Catalog.API.Catalog.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string CategoryName) : ICommand<CreateCatetoryResult>;

public record CreateCatetoryResult(Category category);

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.CategoryName).NotEmpty().WithMessage("CategoryName is required");
    }
}
public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, CreateCatetoryResult>
{
    private CatalogContext _context;
    public CreateCategoryHandler(CatalogContext context)
    {
        _context = context;
    }
    public async Task<CreateCatetoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(Guid.NewGuid(), request.CategoryName);

        await _context.Categories.AddAsync(category);

        await _context.SaveChangesAsync();

        return new CreateCatetoryResult(category);
    }
}
