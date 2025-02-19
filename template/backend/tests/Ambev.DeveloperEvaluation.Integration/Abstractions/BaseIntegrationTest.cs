using Ambev.DeveloperEvaluation.ORM;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Integration.Abstractions;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
{
    private readonly IServiceScope scope;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        scope = factory.Services.CreateScope();
        Sender = scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();
        DbContext.Database.Migrate();
    }

    protected ISender Sender { get; }

    protected DefaultContext DbContext { get; }

    public void Dispose() => scope.Dispose();
}
