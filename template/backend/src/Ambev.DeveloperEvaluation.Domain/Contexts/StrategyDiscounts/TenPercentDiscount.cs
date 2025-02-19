using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Contexts.StrategyDiscounts;

public class TenPercentDiscount : IDiscountStrategy
{
    public bool Applicable(Product product)
        => product.Quantity >= 4.000m && product.Quantity < 10.000m;

    public void CalculateDiscount(Product product)
        => product.ApplyDiscount(0.10m);    
}
