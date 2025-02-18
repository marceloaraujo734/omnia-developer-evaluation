using Ambev.DeveloperEvaluation.Application.Extensions;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;

public sealed class CreateSaleHandler(ISaleRepository _repository, IMapper _mapper, IPublishEvent _publishEvent, ILogger<CreateSaleHandler> _logger)
    : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await command.Validate(cancellationToken);
        if (validationResult.IsValid is false)
        {
            _logger.LogInformation("Data sent to create sale is invalid: {0}", command.ToJson());
            throw new ValidationException(validationResult.Errors);
        }

        _logger.LogInformation("Request to create sale of Number: {0}", command.Number);

        var sale = _mapper.Map<Sale>(command);

        validationResult = await sale.Validate(cancellationToken);
        if (validationResult.IsValid is false)
        {
            _logger.LogInformation("Sale Number {0} did not meet business rules - {1}", command.Number, validationResult.Errors.ToJson());
            throw new ValidationException(validationResult.Errors);
        }

        sale.ApplyDiscounts();

        var result = await _repository.CreateAsync(sale, cancellationToken);

        await _publishEvent.SendMessage("Sale created with succesfully!");

        _logger.LogInformation("Sale Number: {0} with Id: {1}, created with successfully!", command.Number, result.Id);

        var response = _mapper.Map<CreateSaleResult>(result);

        return response;
    }
}
