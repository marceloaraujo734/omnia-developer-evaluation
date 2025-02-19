using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale;

public record CancelSaleCommand(Guid Id) : IRequest<CancelSaleResult>;
