using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSales;
using AutoBogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Queries.GetSales;

internal static class GetSalesQueryMock
{
    internal static GetSalesQuery Builder()
        => AutoFaker.Generate<GetSalesQuery>();
}
