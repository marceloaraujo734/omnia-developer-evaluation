using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoBogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Fixture.Repositories;

internal static class ProductRepositoryMock
{
    internal static Product GetProduct()
        => AutoFaker.Generate<Product>();
}
