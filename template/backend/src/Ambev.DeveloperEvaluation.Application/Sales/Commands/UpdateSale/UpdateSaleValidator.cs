using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;

public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(sale => sale.Id)
            .NotEmpty().WithMessage("The identifier is required!");

        RuleFor(sale => sale.Number)
            .NotEmpty().WithMessage("The number is required!")
            .MaximumLength(50).WithMessage("The sale number cannot exceed 50 characters!");

        RuleFor(sale => sale.OpenDate)
            .NotEmpty().WithMessage("The sale date is required!")
            .LessThanOrEqualTo(DateTime.Now.Date).WithMessage("The sale date cannot be in the future!");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty().WithMessage("The customer id is required!");

        RuleFor(sale => sale.CustomerName)
            .NotEmpty().WithMessage("The customer name is required!")
            .MaximumLength(100).WithMessage("The customer name cannot exceed 100 characters!");

        RuleFor(sale => sale.BranchId)
            .NotEmpty().WithMessage("The branch id is required!");

        RuleFor(sale => sale.BranchName)
            .NotEmpty().WithMessage("The branch is required!")
            .MaximumLength(100).WithMessage("The branch name cannot exceed 100 characters!");

        RuleFor(sale => sale.TotalValue)
            .GreaterThan(0.00m).WithMessage("The total sale value must be greater than zero!");

        RuleFor(sale => sale.Products)
            .NotEmpty().WithMessage("The sale must have at least one product.")
            .Must((sale, products) => products.Sum(product => product.Total) == sale.TotalValue)
            .WithMessage("The total sale amount does not match the sum of the item values.");

        RuleForEach(sale => sale.Products)
            .SetValidator(new UpdateProductValidator());

    }
}
