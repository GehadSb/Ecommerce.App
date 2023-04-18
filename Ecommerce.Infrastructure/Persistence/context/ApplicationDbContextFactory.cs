using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Persistence.context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), @"../Ecommerce.UI/appsettings.json"), true)
        .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"../Ecommerce.UI/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json"), true)
        .Build();

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("EcommerceConnection");
        builder.UseSqlServer(connectionString);
        return new ApplicationDbContext(builder.Options);
    }
}
