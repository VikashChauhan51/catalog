using Catalog.Application.Product.Commands;
using FluentValidation;

namespace Catalog.Application.Product.Validators;
public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
    }
}
