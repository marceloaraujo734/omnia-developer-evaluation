using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSaleProduct;

public sealed class CancelSaleProductHandler(IProductRepository _repository, ILogger<CancelSaleProductHandler> _logger)
    : IRequestHandler<CancelSaleProductCommand, CancelSaleProductResult>
{
    public async Task<CancelSaleProductResult> Handle(CancelSaleProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByKeysAsync(command.SaleId, command.ProductId, cancellationToken);
        if (product is null)
        {
            _logger.LogInformation("Product with this id: {0} in this sale: {1}, not found!", command.ProductId, command.SaleId);
            throw new KeyNotFoundException($"Product with this id: {command.ProductId} in this sale: {command.SaleId}, not found!");
        }

        product.ChangeToCancelled();

        await _repository.UpdateAsync(product, cancellationToken);

        _logger.LogInformation("Product with this id: {0} in this sale: {1}, cancelled with successfully!", command.ProductId, command.SaleId);

        return CancelSaleProductResult.Builder();
    }
}
