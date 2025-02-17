using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesHandler(ISaleRepository _repository, IMapper _mapper) : IRequestHandler<GetSalesCommand, GetSalesResult>
{
    public async Task<GetSalesResult> Handle(GetSalesCommand command, CancellationToken cancellationToken)
    {
        var totalCount = await _repository.GetSalesTotal(cancellationToken);
        var sales = await _repository.GetSalesAsync(command.Page, command.Size, command.Order, cancellationToken);
        
        var response = _mapper.Map<GetSalesResult>(sales);
        response.SetTotalCount(totalCount);

        return response;
    }
}
