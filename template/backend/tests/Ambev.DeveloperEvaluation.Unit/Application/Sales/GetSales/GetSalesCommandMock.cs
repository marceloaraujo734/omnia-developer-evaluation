using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using AutoBogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetSales;

internal static class GetSalesCommandMock
{
    internal static GetSalesCommand Builder()
        => AutoFaker.Generate<GetSalesCommand>();
}
