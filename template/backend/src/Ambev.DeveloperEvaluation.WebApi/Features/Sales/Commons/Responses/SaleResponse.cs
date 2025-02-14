namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Responses;

public record SaleResponse
{
    public Guid Id { get; init; }
    public string Number { get; init; } = string.Empty;
    public DateTime OpenDate { get; init; }
    public Guid CustomerId { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public Guid BranchId { get; init; }
    public string BranchName { get; init; } = string.Empty;
    public decimal TotalValue { get; init; }
    public List<ProductResponse> Products { get; set; } = [];
}
