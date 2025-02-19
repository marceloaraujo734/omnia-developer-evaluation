using Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Commands.UpdateSale;

internal static class UpdateSaleCommandMock
{
    internal static UpdateSaleCommand BuilderEmpty() => new();

    internal static UpdateSaleCommand Builder()
    {
        var products = UpdateProducts();
        var total = products.Sum(opt => opt.Total);

        return new Faker<UpdateSaleCommand>("pt_BR")
            .RuleFor(item => item.Id, fake => fake.Random.Uuid())
            .RuleFor(item => item.CustomerId, fake => fake.Random.Uuid())
            .RuleFor(item => item.CustomerName, fake => fake.Person.FirstName)
            .RuleFor(item => item.BranchId, fake => fake.Random.Uuid())
            .RuleFor(item => item.BranchName, fake => fake.Company.CompanyName())
            .RuleFor(item => item.TotalValue, _ => total)
            .RuleFor(item => item.Products, _ => products)
            .Generate();
    }

    private static List<ProductCommand> UpdateProducts()
    {
        return new Faker<ProductCommand>("pt_BR")
            .RuleFor(item => item.ProductId, fake => fake.Random.Uuid())
            .RuleFor(item => item.Quantity, fake => Math.Round(fake.Random.Decimal(0.001m, 20.000m), 3))
            .RuleFor(item => item.Price, fake => Math.Round(fake.Random.Decimal(0.01m, 100.00m), 2))
            .RuleFor(item => item.Total, (_, item) => Math.Round(item.Quantity * item.Price, 2))
            .Generate(2);
    }
}
