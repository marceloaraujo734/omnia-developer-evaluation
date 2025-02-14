using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateProductValidator : AbstractValidator<ProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(product => product.ProductId)
            .NotEmpty().WithMessage("The product name is required!");

        RuleFor(product => product.Quantity)
            .GreaterThan(0.000m).WithMessage("The quantity must be greater than zero!")
            .LessThanOrEqualTo(20.000m).WithMessage("The quantity cannot exceed 20.000!");

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("The unit price must be greater than zero!");

        RuleFor(product => product.Total)
            .Equal(product => product.Quantity * product.Price)
            .GreaterThan(0.00m).WithMessage("The total sales value cannot be different from the sum of quantity times the product's unit price!");
    }
}
