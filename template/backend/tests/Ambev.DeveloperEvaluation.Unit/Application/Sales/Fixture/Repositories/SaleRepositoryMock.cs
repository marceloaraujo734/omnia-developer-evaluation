using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoBogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Fixture.Repositories;

internal static class SaleRepositoryMock
{
    internal static Sale GetSale()
        => new AutoFaker<Sale>().Generate();

    internal static List<Sale> GetSales()
        => new AutoFaker<Sale>().Generate(2);

    internal static List<Sale> GetSalesEmpty() => new();
}
