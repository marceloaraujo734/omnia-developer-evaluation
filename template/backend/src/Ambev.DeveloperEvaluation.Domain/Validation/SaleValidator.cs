using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.Products)
            .Must((sale, products) => products.Sum(product => product.Total) == sale.TotalValue)
            .WithMessage("The total sale amount does not match the sum of the item values.");

        RuleForEach(sale => sale.Products)
            .SetValidator(new ProductValidator());
    }
}
