using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commons.Extensions;

internal static class ProductsExtension
{
    internal static List<Product> GroupByProductId(this List<ProductCommand> products)
    {
        return products
            .GroupBy(product => product.ProductId)
            .Select(result =>
            {
                var product = result.First();
                var quantity = result.Sum(opt => opt.Quantity);
                var total = result.Sum(opt => opt.Total);

                return Product.Builder(product.ProductId, quantity, product.Price, total);
            })
            .ToList();
    }
}
