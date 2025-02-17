using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public record GetSalesResult()
{
    public List<SaleResult> Sales { get; init; } = [];

    public int TotalCount { get; private set; }

    public int Page { get; private set; }

    public int Size { get; private set; }

    internal void SetTotalCount(int totalCount)
        => TotalCount = totalCount;

    internal void SetPagination(int page, int size)
        => (Page, Size) = (page, size);
}
