using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository(DefaultContext _context) : IProductRepository
{
    public async Task<Product?> GetByKeysAsync(Guid saleId, Guid productId, CancellationToken cancellationToken)
        => await _context.Products.FirstOrDefaultAsync(item => item.SaleId == saleId && item.ProductId == productId, cancellationToken);

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Update(product).DetectChanges();

        await _context.SaveChangesAsync(cancellationToken);

        return product;
    }
}
