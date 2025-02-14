using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleProduct;

public class CreateSaleProductProfile : Profile
{
    public CreateSaleProductProfile()
    {
        CreateMap<ProductCommand, Product>();

        CreateMap<CreateSaleProductCommand, List<Product>>()
            .ConvertUsing((src, dest, context) => context.Mapper.Map<List<Product>>(src.Products));
    }
}
