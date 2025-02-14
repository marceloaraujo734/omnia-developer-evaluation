namespace Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;

public record ProductCommand
{
    public Guid ProductId { get; init; }
    //public Guid SaleId { get; private set; }
    public decimal Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal Total { get; init; }

    //public void SetSaleId(Guid saleId)
    //    => SaleId = saleId;
}
