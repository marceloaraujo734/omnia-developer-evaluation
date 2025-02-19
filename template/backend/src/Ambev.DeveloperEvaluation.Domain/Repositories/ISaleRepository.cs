using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken);

    Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken);

    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<Sale>> GetSalesAsync(int page, int size, string order, CancellationToken cancellationToken);

    Task<int> GetSalesTotal(CancellationToken cancellationToken);
}
