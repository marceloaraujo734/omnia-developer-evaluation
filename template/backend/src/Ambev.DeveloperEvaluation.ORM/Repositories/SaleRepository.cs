using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository(DefaultContext _context) : ISaleRepository
{
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return sale;
    }

    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken)
    {
        _context.Sales.Update(sale).DetectChanges();

        await _context.SaveChangesAsync(cancellationToken);

        return sale;
    }

    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Sales.Include(item => item.Products).FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

    public async Task<List<Sale>> GetSalesAsync(int page, int size, string order, CancellationToken cancellationToken)
    {
        var query = _context.Sales
                        .Include(item => item.Products)
                        .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(order)) query = query.OrderBy(order);

        var result = await query
                        .Skip((page - 1) * size)
                        .Take(size)
                        .ToListAsync(cancellationToken);

        return result;
    }

    public async Task<int> GetProductsTotal(CancellationToken cancellationToken)
        => await _context.Products.CountAsync(cancellationToken);
}
