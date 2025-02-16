using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Requests;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Responses;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<ProductRequest, ProductCommand>();
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>()            
            .AfterMap((src, dest, context) =>
            {
                var id = context.Items["Id"] as Guid?;
                dest.SetId(id ?? Guid.Empty);
            });

        CreateMap<ProductResult, ProductResponse>();
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();
    }
}
