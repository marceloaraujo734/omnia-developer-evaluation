using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public sealed class CancelSaleHandler(ISaleRepository _repository, IMapper _mapper) : IRequestHandler<CancelSaleCommand, CancelSaleResult>
{
    public async Task<CancelSaleResult> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (sale == null)
        {
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");
        }

        sale.ChangeToCancelled();

        var result = await _repository.UpdateAsync(sale, cancellationToken);

        var response = _mapper.Map<CancelSaleResult>(result);

        return response;
    }
}
