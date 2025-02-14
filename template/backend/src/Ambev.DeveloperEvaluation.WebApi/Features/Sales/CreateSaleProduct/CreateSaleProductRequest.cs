using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Requests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSaleProduct;

public record CreateSaleProductRequest(List<ProductRequest> Products);
