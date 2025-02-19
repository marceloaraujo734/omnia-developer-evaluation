using Ambev.DeveloperEvaluation.Application.Extensions;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;

public sealed class UpdateSaleHandler(ISaleRepository _repository, IMapper _mapper, IPublishEvent _publishEvent, ILogger<UpdateSaleHandler> _logger)
    : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await command.Validate(cancellationToken);
        if (validationResult.IsValid is false)
        {
            _logger.LogInformation("Data sent to update sale is invalid: {0}", command.ToJson());
            throw new ValidationException(validationResult.Errors);
        }

        var sale = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (sale is null)
        {
            _logger.LogInformation("Sale Id: {command.Id}, not found!", command.Id);
            throw new KeyNotFoundException($"Sale Id: {command.Id}, not found!");
        }

        _logger.LogInformation("Request to update sale of Id: {0}", command.Id);

        var saleUpdate = _mapper.Map<Sale>(command);

        sale.ChangeCustomer(saleUpdate.CustomerId, command.CustomerName);
        sale.ChangeBranch(saleUpdate.BranchId, command.BranchName);
        sale.ChangeProducts(saleUpdate.Products);

        validationResult = await sale.Validate(cancellationToken);
        if (validationResult.IsValid is false)
        {
            _logger.LogInformation("Sale Id {0} did not meet business rules - {1}", command.Id, validationResult.Errors.ToJson());
            throw new ValidationException(validationResult.Errors);
        }

        sale.ApplyDiscounts();

        var result = await _repository.UpdateAsync(sale, cancellationToken);

        await _publishEvent.SendMessage("Sale created with succesfully!");

        _logger.LogInformation("Sale Id: {1}, updated with successfully!", command.Id);

        var response = _mapper.Map<UpdateSaleResult>(result);

        return response;
    }
}
