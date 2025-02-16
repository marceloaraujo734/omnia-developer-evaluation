using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleProduct;

public record CancelSaleProductCommand : IRequest<CancelSaleProductResult>
{
    public Guid SaleId { get; init; }
    public Guid ProductId { get; init; }
}
