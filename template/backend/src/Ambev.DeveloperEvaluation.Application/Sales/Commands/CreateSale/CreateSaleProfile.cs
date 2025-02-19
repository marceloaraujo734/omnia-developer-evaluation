using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands.Extensions;
using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.GroupByProductId()));

        CreateMap<Product, ProductResult>();
        CreateMap<Sale, CreateSaleResult>();
    }
}
