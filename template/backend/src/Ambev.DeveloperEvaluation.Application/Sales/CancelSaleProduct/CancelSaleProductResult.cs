namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleProduct;

public record CancelSaleProductResult(bool Success)
{
    public static CancelSaleProductResult Builder() => new(true);    
}
