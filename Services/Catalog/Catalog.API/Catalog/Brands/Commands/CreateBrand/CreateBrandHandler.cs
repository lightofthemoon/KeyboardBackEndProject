using Catalog.API.Data;
using Catalog.API.DTOs;
using Catalog.API.Models;
using FluentValidation;
using System.Data;

namespace Catalog.API.Catalog.Brands.Commands.CreateBrand;

public record CreateBrandCommand(CreateBrandDTO BrandDto) : ICommand<CreateBrandResult>;

public record CreateBrandResult(Brand Brand);

public class CreateBrandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandValidator()
    {
        RuleFor(x => x.BrandDto.BrandName).NotEmpty().WithMessage("BrandName is required");
    }
}

public class CreateBrandHandler : ICommandHandler<CreateBrandCommand, CreateBrandResult>
{
    private readonly CatalogContext _context;
    public CreateBrandHandler(CatalogContext context)
    {
        _context = context;
    }
    public async Task<CreateBrandResult> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = new Brand(Guid.NewGuid(), request.BrandDto.BrandName);

        brand.PhoneNumber = request.BrandDto.PhoneNumber;
        brand.Email = request.BrandDto.Email;

        await _context.Brand.AddAsync(brand);

        await _context.SaveChangesAsync();

        return new CreateBrandResult(brand);
    }
}