using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Contexts.StrategyDiscounts;

public class TwentyPercentDiscount : IDiscountStrategy
{
    public bool Applicable(Product product)
        => product.Quantity >= 10.000m && product.Quantity <= 20.000m;

    public void CalculateDiscount(Product product)
        => product.ApplyDiscount(0.20m);
}
