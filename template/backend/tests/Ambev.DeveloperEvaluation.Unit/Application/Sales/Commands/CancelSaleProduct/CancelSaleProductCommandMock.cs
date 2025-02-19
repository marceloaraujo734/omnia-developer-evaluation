using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSaleProduct;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Commands.CancelSaleProduct;

internal static class CancelSaleProductCommandMock
{
    internal static CancelSaleProductCommand Builder()
    {
        return new Faker<CancelSaleProductCommand>("pt_BR")
            .RuleFor(item => item.SaleId, fake => fake.Random.Uuid())
            .RuleFor(item => item.ProductId, fake => fake.Random.Uuid())
            .Generate();
    }
}
