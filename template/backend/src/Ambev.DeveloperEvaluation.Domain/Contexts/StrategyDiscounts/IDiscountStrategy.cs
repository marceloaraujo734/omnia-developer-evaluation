using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Contexts.StrategyDiscounts;

public interface IDiscountStrategy
{
    bool Applicable(Product product);

    void CalculateDiscount(Product product);
}
