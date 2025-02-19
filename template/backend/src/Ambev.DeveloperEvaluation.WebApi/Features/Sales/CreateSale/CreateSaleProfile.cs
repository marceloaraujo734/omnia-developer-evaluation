using Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using Ambev.DeveloperEvaluation.Application.Sales.Commons.Results;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Requests;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Responses;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<ProductRequest, ProductCommand>();
        CreateMap<CreateSaleRequest, CreateSaleCommand>();

        CreateMap<ProductResult, ProductResponse>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
    }
}
