using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public sealed class GetSaleHandler(ISaleRepository _repository, IMapper _mapper, ILogger<GetSaleHandler> _logger)
    : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    public async Task<GetSaleResult> Handle(GetSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (sale is null)
        {
            _logger.LogInformation("Sale Id: {command.Id}, not found!", command.Id);
            throw new KeyNotFoundException($"Sale Id: {command.Id} not found!");
        }

        _logger.LogInformation("Sale to Id: {command.Id}, found with successfully!", command.Id);

        return _mapper.Map<GetSaleResult>(sale);
    }
}
