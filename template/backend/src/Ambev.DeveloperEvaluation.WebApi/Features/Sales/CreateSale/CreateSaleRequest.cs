using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Requests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public record CreateSaleRequest : SaleRequest
{
    public string Number { get; init; } = string.Empty;
    public DateTime OpenDate { get; init; }
}
