using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public record GetSalesCommand(int Page, int Size, string Order) : IRequest<GetSalesResult>;
