using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Responses;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public record GetSalesResponse
{
    public List<SaleResponse> Sales { get; init; } = [];

    public int TotalCount { get; init; }
}
