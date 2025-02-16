namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public record CancelSaleResult(bool Success)
{
    public static CancelSaleResult Builder() => new(true);    
}
