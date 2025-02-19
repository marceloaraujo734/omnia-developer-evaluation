using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;

namespace Ambev.DeveloperEvaluation.Integration.Abstractions;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer dataBaseContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
#if RUN_LOCAL
        .WithDockerEndpoint("tcp://localhost:2375")
#endif
        .WithDatabase("evaluation")
        .WithUsername("developer")
        .WithPassword("ev@luAt10n")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<DefaultContext>));

            services.AddDbContext<DefaultContext>(options => options.UseNpgsql(dataBaseContainer.GetConnectionString()));
        });

        base.ConfigureWebHost(builder);
    }

    public async Task InitializeAsync()
    {
        await dataBaseContainer.StartAsync();        
    }

    public new async Task DisposeAsync()
    {
        await dataBaseContainer.StopAsync();        
    }
}

