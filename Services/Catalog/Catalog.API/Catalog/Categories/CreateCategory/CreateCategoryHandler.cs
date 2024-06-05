using Catalog.API.Catalog.Categories.Repositories;
using Catalog.API.Models;
using FluentValidation;
using System.Reflection.Metadata;

namespace Catalog.API.Catalog.Categories.CreateCategory;

public record CreateCategoryCommand(string CategoryName) : ICommand<CreateCatetoryResult>;

public record CreateCatetoryResult(Guid id);

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.CategoryName).NotEmpty().WithMessage("CategoryName is required");
    }
}
public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, CreateCatetoryResult>
{
    private readonly ICategoryRepository _repository;
    public CreateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<CreateCatetoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.CategoryName);
        category.CategoryId = Guid.NewGuid();

        await _repository.AddAsync(category);
        
        throw new NotImplementedException();
    }
}
