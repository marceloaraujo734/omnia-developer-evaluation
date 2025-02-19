using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;

public record UpdateSaleCommand : SaleCommand, IRequest<UpdateSaleResult>
{
    public Guid Id { get; private set; }

    public void SetId(Guid id) => Id = id;

    internal async Task<ValidationResult> Validate(CancellationToken cancellationToken)
        => await new UpdateSaleValidator().ValidateAsync(this, cancellationToken);
}

