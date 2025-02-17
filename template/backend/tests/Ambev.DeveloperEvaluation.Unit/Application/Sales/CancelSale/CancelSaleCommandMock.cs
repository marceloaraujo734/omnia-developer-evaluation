using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CancelSale;

internal static class CancelSaleCommandMock
{
    internal static CancelSaleCommand Builder()
    {
        var faker = new Faker<CancelSaleCommand>("pt_BR")
            .CustomInstantiator(fake => new CancelSaleCommand(fake.Random.Uuid()))
            .Generate();

        return faker;
    }
}
