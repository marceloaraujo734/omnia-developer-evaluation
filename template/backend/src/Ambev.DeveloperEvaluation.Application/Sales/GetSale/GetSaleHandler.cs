using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public sealed class GetSaleHandler(ISaleRepository _repository, IMapper _mapper) : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    public async Task<GetSaleResult> Handle(GetSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (sale is null)
        {
            throw new KeyNotFoundException($"Sale Id: {command.Id} not found!");
        }

        return _mapper.Map<GetSaleResult>(sale);
    }
}
