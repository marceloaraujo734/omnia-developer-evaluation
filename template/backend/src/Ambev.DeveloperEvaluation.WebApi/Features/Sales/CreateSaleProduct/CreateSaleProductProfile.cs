using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSaleProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Responses;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSaleProduct
{
    public class CreateSaleProductProfile : Profile
    {
        public CreateSaleProductProfile()
        {
            //CreateMap<ProductRequest, ProductCommand>()
            //    .AfterMap((src, dest, context) =>
            //    {
            //        var saleId = context.Items["SaleId"] as Guid?;
            //        dest.SetSaleId(saleId ?? Guid.Empty);
            //    });

            CreateMap<CreateSaleProductRequest, CreateSaleProductCommand>();

            CreateMap<ProductResult, ProductResponse>();
        }
    }
}
