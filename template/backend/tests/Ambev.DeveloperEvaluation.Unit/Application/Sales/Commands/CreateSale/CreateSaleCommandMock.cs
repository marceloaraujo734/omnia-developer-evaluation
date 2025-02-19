using Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Commands.CreateSale;

internal static class CreateSaleCommandMock
{
    internal static CreateSaleCommand BuilderEmpty() => new();

    internal static CreateSaleCommand Builder()
    {
        var products = CreateProducts();
        var total = products.Sum(opt => opt.Total);

        return new Faker<CreateSaleCommand>("pt_BR")
            .RuleFor(item => item.Number, fake => fake.Random.String(3, 50))
            .RuleFor(item => item.OpenDate, fake => fake.Date.Past())
            .RuleFor(item => item.CustomerId, fake => fake.Random.Uuid())
            .RuleFor(item => item.CustomerName, fake => fake.Person.FirstName)
            .RuleFor(item => item.BranchId, fake => fake.Random.Uuid())
            .RuleFor(item => item.BranchName, fake => fake.Company.CompanyName())
            .RuleFor(item => item.TotalValue, fake => total)
            .RuleFor(item => item.Products, fake => products)
            .Generate();
    }

    private static List<ProductCommand> CreateProducts()
    {
        return new Faker<ProductCommand>("pt_BR")
            .RuleFor(item => item.ProductId, fake => fake.Random.Uuid())
            .RuleFor(item => item.Quantity, fake => Math.Round(fake.Random.Decimal(0.001m, 20.000m), 3))
            .RuleFor(item => item.Price, fake => Math.Round(fake.Random.Decimal(0.01m, 100.00m), 2))
            .RuleFor(item => item.Total, (_, item) => Math.Round(item.Quantity * item.Price, 2))
            .Generate(2);
    }
}
