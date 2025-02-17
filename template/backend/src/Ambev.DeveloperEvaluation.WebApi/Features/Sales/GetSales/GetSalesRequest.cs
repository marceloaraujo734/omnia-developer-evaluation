namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public record GetSalesRequest(int Page, int Size, string Order)
{
    public static GetSalesRequest Builder(int page, int size, string order)
        => new(page, size, order);
}
