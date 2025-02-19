using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByKeysAsync(Guid saleId, Guid productId, CancellationToken cancellationToken);

    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken);
}
