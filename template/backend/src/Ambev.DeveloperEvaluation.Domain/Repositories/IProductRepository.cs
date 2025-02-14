using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<List<Product>> CreateAsync(List<Product> products, CancellationToken cancellationToken);
}
