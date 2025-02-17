using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public sealed class CancelSaleHandler(ISaleRepository _repository, ILogger<CancelSaleHandler> _logger)
    : IRequestHandler<CancelSaleCommand, CancelSaleResult>
{
    public async Task<CancelSaleResult> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (sale is null)
        {
            _logger.LogInformation("Sale Id: {command.Id}, not found!", command.Id);
            throw new KeyNotFoundException($"Sale Id: {command.Id}, not found!");
        }

        sale.ChangeToCancelled();

        await _repository.UpdateAsync(sale, cancellationToken);

        _logger.LogInformation("Sale Id: {command.Id}, cancelled with successfully!", command.Id);

        return CancelSaleResult.Builder();
    }
}
