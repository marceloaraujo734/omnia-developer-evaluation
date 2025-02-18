using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Product, ProductResult>();
        CreateMap<Sale, GetSaleResult>();
    }
}
