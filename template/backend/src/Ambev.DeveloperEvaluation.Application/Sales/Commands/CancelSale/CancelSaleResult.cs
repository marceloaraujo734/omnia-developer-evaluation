namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale;

public record CancelSaleResult(bool Success)
{
    public static CancelSaleResult Builder() => new(true);
}
