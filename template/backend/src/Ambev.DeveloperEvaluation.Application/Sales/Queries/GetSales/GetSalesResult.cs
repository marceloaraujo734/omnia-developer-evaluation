using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSales;

public record GetSalesResult()
{
    public List<SaleResult> Sales { get; init; } = [];

    public int TotalCount { get; private set; }

    internal void SetTotalCount(int totalCount)
        => TotalCount = totalCount;
}
