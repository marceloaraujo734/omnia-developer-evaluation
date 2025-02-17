using Ambev.DeveloperEvaluation.Application.Sales.CancelSaleProduct;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CancelSaleProduct;

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
