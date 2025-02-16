using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Quantity)            
            .LessThanOrEqualTo(20.000m)
            .WithMessage(product => $"The quantity of product {product.ProductId} exceeded the allowed limit!");
    }
}
