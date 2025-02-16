using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public sealed class CreateSaleHandler(ISaleRepository _repository, IMapper _mapper) : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await command.Validate(cancellationToken);
        if (validationResult.IsValid is false)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var sale = _mapper.Map<Sale>(command);
        
        validationResult = await sale.Validate(cancellationToken);
        if (validationResult.IsValid is false)
        {
            throw new ValidationException(validationResult.Errors);
        }

        sale.ApplyDiscounts();

        var result = await _repository.CreateAsync(sale, cancellationToken);

        var response = _mapper.Map<CreateSaleResult>(result);

        return response;
    }
}
