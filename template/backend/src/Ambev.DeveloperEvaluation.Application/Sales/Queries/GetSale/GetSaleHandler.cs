using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;

public sealed class GetSaleHandler(ISaleRepository _repository, IMapper _mapper, ILogger<GetSaleHandler> _logger)
    : IRequestHandler<GetSaleQuery, GetSaleResult>
{
    public async Task<GetSaleResult> Handle(GetSaleQuery query, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(query.Id, cancellationToken);
        if (sale is null)
        {
            _logger.LogInformation("Sale Id: {0}, not found!", query.Id);
            throw new KeyNotFoundException($"Sale Id: {query.Id} not found!");
        }

        _logger.LogInformation("Sale to Id: {0}, found with successfully!", query.Id);

        return _mapper.Map<GetSaleResult>(sale);
    }
}
