using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository(DefaultContext _context) : IProductRepository
{
    public async Task<List<Product>> CreateAsync(List<Product> products, CancellationToken cancellationToken)
    {
        await _context.Products.AddRangeAsync(products, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return products;
    }
}
