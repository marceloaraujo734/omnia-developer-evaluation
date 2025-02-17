using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetSale;

internal static class GetSaleCommandMock
{
    internal static GetSaleCommand Builder()
    {
        var faker = new Faker<GetSaleCommand>("pt_BR")
            .CustomInstantiator(fake => new GetSaleCommand(fake.Random.Uuid()))
            .Generate();

        return faker;
    }
}
