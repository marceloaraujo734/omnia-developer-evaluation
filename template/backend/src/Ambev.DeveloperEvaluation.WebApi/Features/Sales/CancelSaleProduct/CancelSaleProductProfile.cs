using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSaleProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleProduct;

public class CancelSaleProductProfile : Profile
{
    public CancelSaleProductProfile()
    {
        CreateMap<CancelSaleProductRequest, CancelSaleProductCommand>();
    }
}
