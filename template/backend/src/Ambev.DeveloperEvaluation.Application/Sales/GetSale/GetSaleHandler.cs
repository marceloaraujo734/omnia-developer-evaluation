using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public sealed class GetSaleHandler(ISaleRepository _repository, IMapper _mapper) : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    public async Task<GetSaleResult> Handle(GetSaleCommand command, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(command.Id, cancellationToken);

        var response = _mapper.Map<GetSaleResult>(result);

        return response;
    }
}
