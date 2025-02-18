using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Responses;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Guid, GetSaleQuery>()
            .ConstructUsing(id => new GetSaleQuery(id));

        CreateMap<ProductResult, ProductResponse>();
        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
