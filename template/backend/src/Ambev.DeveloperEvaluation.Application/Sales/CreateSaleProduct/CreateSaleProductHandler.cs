using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleProduct;

public sealed class CreateSaleProductHandler(IProductRepository _repository, IMapper _mapper) : IRequestHandler<CreateSaleProductCommand, CreateSaleProductResult>
{
    public async Task<CreateSaleProductResult> Handle(CreateSaleProductCommand command, CancellationToken cancellationToken)
    {
        var products = _mapper.Map<List<Product>>(command);

        var result = await _repository.CreateAsync(products, cancellationToken);

        var response = _mapper.Map<CreateSaleProductResult>(result);

        return response;
    }
}
