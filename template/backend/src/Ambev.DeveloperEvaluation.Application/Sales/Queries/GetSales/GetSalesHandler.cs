using Ambev.DeveloperEvaluation.Application.Extensions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSales;

public class GetSalesHandler(ISaleRepository _repository, IMapper _mapper, ILogger<GetSalesHandler> _logger)
    : IRequestHandler<GetSalesQuery, GetSalesResult>
{
    public async Task<GetSalesResult> Handle(GetSalesQuery query, CancellationToken cancellationToken)
    {
        var sales = await _repository.GetSalesAsync(query.Page, query.Size, query.Order, cancellationToken);
        if (sales is null or { Count: 0 })
        {
            _logger.LogInformation("Sales not found!");
            throw new KeyNotFoundException($"Sales not found!");
        }

        var totalCount = await _repository.GetSalesTotal(cancellationToken);

        var response = _mapper.Map<GetSalesResult>(sales);
        response.SetTotalCount(totalCount);

        _logger.LogInformation("Sales successfully achieved with the following parameters: {0}!", query.ToJson());

        return response;
    }
}
