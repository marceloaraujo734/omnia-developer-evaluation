namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleProduct;

public record CancelSaleProductRequest(Guid SaleId, Guid ProductId)
{
    public static CancelSaleProductRequest Builder(Guid saleId, Guid prodcutId) => new(saleId, prodcutId);
}
