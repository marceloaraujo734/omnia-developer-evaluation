using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Queries.GetSale;

internal static class GetSaleCommandMock
{
    internal static GetSaleQuery Builder()
    {
        var faker = new Faker<GetSaleQuery>("pt_BR")
            .CustomInstantiator(fake => new GetSaleQuery(fake.Random.Uuid()))
            .Generate();

        return faker;
    }
}
