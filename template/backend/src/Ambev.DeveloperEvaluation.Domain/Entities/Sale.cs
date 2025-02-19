using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contexts.StrategyDiscounts;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    private readonly IDiscountStrategy[] strategies = [new TenPercentDiscount(), new TwentyPercentDiscount()];

    public string Number { get; init; } = string.Empty;
    public DateTime OpenDate { get; init; }
    public Guid CustomerId { get; private set; }
    public string CustomerName { get; private set; } = string.Empty;
    public Guid BranchId { get; private set; }
    public string BranchName { get; private set; } = string.Empty;
    public decimal TotalValue { get; private set; }
    public bool Canceled { get; private set; } = false;
    public List<Product> Products { get; private set; } = [];
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }

    public async Task<ValidationResult> Validate(CancellationToken cancellationToken)
        => await new SaleValidator().ValidateAsync(this, cancellationToken);

    public void SetTotalValue(decimal totalValue)
        => TotalValue = totalValue;

    public void ApplyDiscounts()
    {
        Products.ForEach(product =>
        {
            var strategy = strategies.FirstOrDefault(opt => opt.Applicable(product));

            strategy?.CalculateDiscount(product);
        });

        SetTotalValue(Products.Sum(product => product.Total));
    }

    public void ChangeCustomer(Guid customerId, string custormerName)
    {
        CustomerId = customerId;
        CustomerName = custormerName;
    }

    public void ChangeBranch(Guid branchId, string branchName)
    {
        BranchId = branchId;
        BranchName = branchName;
    }

    public void ChangeProducts(List<Product> products)
    {
        foreach (var product in products)
        { 
            var result = Products.FirstOrDefault(item => item.ProductId == product.ProductId);
            if (result is not null)
            {
                result.ChangeValues(product);
                continue;
            }

            Products.Add(product);
        }

        SetTotalValue(Products.Sum(item => item.Total));
    }

    public void ChangeToCancelled() => Canceled = true;
}
