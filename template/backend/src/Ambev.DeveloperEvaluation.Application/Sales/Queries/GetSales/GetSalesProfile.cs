using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSales;

public class GetSalesProfile : Profile
{
    public GetSalesProfile()
    {
        CreateMap<Product, ProductResult>();

        CreateMap<Sale, SaleResult>();

        CreateMap<List<Sale>, GetSalesResult>()
            .ForMember(destination => destination.Sales, option => option.MapFrom(source => source));
    }
}
