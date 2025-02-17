using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleProduct;

public sealed class CancelSaleProductHandler(IProductRepository _repository) : IRequestHandler<CancelSaleProductCommand, CancelSaleProductResult>
{
    public async Task<CancelSaleProductResult> Handle(CancelSaleProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByKeysAsync(command.SaleId, command.ProductId, cancellationToken);
        if (product is null)
        {
            throw new KeyNotFoundException($"product with this id: {command.ProductId} in this sale: {command.SaleId}, not found!");
        }

        product.ChangeToCancelled();

        await _repository.UpdateAsync(product, cancellationToken);

        return CancelSaleProductResult.Builder();
    }
}
