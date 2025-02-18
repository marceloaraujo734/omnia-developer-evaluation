namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSaleProduct;

public record CancelSaleProductResult(bool Success)
{
    public static CancelSaleProductResult Builder() => new(true);
}
