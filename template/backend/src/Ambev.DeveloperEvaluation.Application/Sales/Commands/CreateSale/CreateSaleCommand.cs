using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;

public record CreateSaleCommand : SaleCommand, IRequest<CreateSaleResult>
{
    public string Number { get; init; } = string.Empty;
    public DateTime OpenDate { get; init; }

    internal async Task<ValidationResult> Validate(CancellationToken cancellationToken)
        => await new CreateSaleValidator().ValidateAsync(this, cancellationToken);
}

