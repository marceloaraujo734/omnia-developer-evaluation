using Ambev.DeveloperEvaluation.Application.Sales.Commons.Commands;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleProduct;

public record CreateSaleProductCommand(List<ProductCommand> Products) : IRequest<CreateSaleProductResult>;
