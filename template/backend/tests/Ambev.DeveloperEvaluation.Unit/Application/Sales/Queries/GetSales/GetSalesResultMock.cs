using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSales;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Queries.GetSales;

internal static class GetSalesResultMock
{
    internal static GetSalesResult Builder(List<Sale> sales)
    {
        return new GetSalesResult
        {
            Sales = GetSaleResults(sales),
        };
    }

    private static List<SaleResult> GetSaleResults(List<Sale> sales)
    {
        return sales.ConvertAll(sale => new SaleResult
        {
            Id = sale.Id,
            Number = sale.Number,
            OpenDate = sale.OpenDate,
            CustomerId = sale.CustomerId,
            CustomerName = sale.CustomerName,
            BranchId = sale.BranchId,
            BranchName = sale.BranchName,
            TotalValue = sale.TotalValue,
            Canceled = sale.Canceled,
            Products = GetProductResults(sale.Products),
        });
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
