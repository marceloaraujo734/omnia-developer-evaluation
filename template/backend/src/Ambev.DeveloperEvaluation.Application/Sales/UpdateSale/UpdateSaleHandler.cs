using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public sealed class UpdateSaleHandler(ISaleRepository _repository, IMapper _mapper) : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await command.Validate(cancellationToken);
        if (validationResult.IsValid is false) throw new ValidationException(validationResult.Errors);

        var sale = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (sale == null)
        {
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");
        }

        var newSale = _mapper.Map<Sale>(command);

        sale.ChangeCustomer(newSale.CustomerId, command.CustomerName);
        sale.ChangeBranch(newSale.BranchId, command.BranchName);
        sale.ChangeProducts(newSale.Products);
        sale.SetTotalValue(newSale.TotalValue);

        validationResult = await sale.Validate(cancellationToken);
        if (validationResult.IsValid is false)
        {
            throw new ValidationException(validationResult.Errors);
        }

        sale.ApplyDiscounts();

        var result = await _repository.UpdateAsync(sale, cancellationToken);

        var response = _mapper.Map<UpdateSaleResult>(result);

        return response;
    }
}
