using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetSale;

internal static class GetSaleResultMock
{
    internal static GetSaleResult Builder(Sale saleMock)
    {
        return new GetSaleResult()
        {
            Id = saleMock.Id,
            Number = saleMock.Number,
            OpenDate = saleMock.OpenDate,
            CustomerId = saleMock.CustomerId,
            CustomerName = saleMock.CustomerName,
            BranchId = saleMock.BranchId,
            BranchName = saleMock.BranchName,
            TotalValue = saleMock.TotalValue,
            Canceled = saleMock.Canceled,
            Products = GetProductResults(saleMock.Products),
        };
    }

    private static List<ProductResult> GetProductResults(List<Product> products)
    { 
        return products.ConvertAll(product => new ProductResult
        {
            ProductId = product.ProductId,
            Quantity = product.Quantity,
            Price = product.Price,
            Total = product.Total,
            Discount = product.Discount,
            Canceled = product.Canceled,
        });
    }
}
