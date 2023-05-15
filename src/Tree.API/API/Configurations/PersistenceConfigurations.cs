using Application.Interfaces;
using Infrastructure.Configurations.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Repositories;

namespace API.Configurations
{
    public static class PersistenceConfigurations
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder applicationBuilder)
        {
            var serviecProvider = applicationBuilder.Services.BuildServiceProvider();
            var connectionStrings = serviecProvider.GetRequiredService<IOptions<ConnectionStrings>>().Value;

            applicationBuilder.Services.AddDbContext<Persistence.DbContext>(
                opts => opts.UseLazyLoadingProxies()
                            .UseNpgsql(connectionStrings.Db));

            applicationBuilder.Services.AddTransient<INodeRepository, NodeRepository>();
            applicationBuilder.Services.AddTransient<IJournalRepository, JournalRepository>();

            return applicationBuilder;
        }

        public static WebApplication UseDbMigrations(this WebApplication webApplication) 
        {
            using var serviceScope = webApplication.Services
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var dbContext = serviceScope.ServiceProvider.GetRequiredService<Persistence.DbContext>();
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }

            return webApplication;
        }
    }
}
