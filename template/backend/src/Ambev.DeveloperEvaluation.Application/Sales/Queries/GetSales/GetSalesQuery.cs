using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSales;

public record GetSalesQuery(int Page, int Size, string Order) : IRequest<GetSalesResult>;
