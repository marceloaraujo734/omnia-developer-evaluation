using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public sealed class CancelSaleHandler(ISaleRepository _repository) : IRequestHandler<CancelSaleCommand, CancelSaleResult>
{
    public async Task<CancelSaleResult> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (sale is null)
        {
            throw new KeyNotFoundException($"Sale Id: {command.Id}, not found!");
        }

        sale.ChangeToCancelled();

        await _repository.UpdateAsync(sale, cancellationToken);

        return CancelSaleResult.Builder();
    }
}
