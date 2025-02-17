using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.UpdateSale;

internal static class UpdateSaleMapperMock
{
    internal static Sale CommandToEntityInvalid(UpdateSaleCommand command)
    {
        var sale = new Sale()
        {
            Id = command.Id,
            Number = command.Number,
            OpenDate = command.OpenDate,
            CreatedAt = DateTime.UtcNow,
        };

        sale.ChangeCustomer(command.CustomerId, command.CustomerName);
        sale.ChangeBranch(command.BranchId, command.BranchName);
        sale.SetTotalValue(command.TotalValue);
        sale.ChangeProducts(GetProductsInvalid(command.Products));

        return sale;
    }


    internal static Sale CommandToEntity(UpdateSaleCommand command)
    {
        var sale = new Sale()
        {
            Id = command.Id,
            Number = command.Number,
            OpenDate = command.OpenDate,
            CreatedAt = DateTime.UtcNow,
        };

        sale.ChangeCustomer(command.CustomerId, command.CustomerName);
        sale.ChangeBranch(command.BranchId, command.BranchName);
        sale.SetTotalValue(command.TotalValue);
        sale.ChangeProducts(GetProducts(command.Products));

        return sale;
    }

    internal static UpdateSaleResult EntityToResult(Sale saleMock)
    {
        return new UpdateSaleResult
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

    private static List<Product> GetProductsInvalid(List<ProductCommand> products)
        => products.ConvertAll(product => Product.Builder(product.ProductId, 20.001m, product.Price, product.Total));

    private static List<Product> GetProducts(List<ProductCommand> products)
        => products.ConvertAll(product => Product.Builder(product.ProductId, product.Quantity, product.Price, product.Total));

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
