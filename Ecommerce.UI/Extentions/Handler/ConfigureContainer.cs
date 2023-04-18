using Microsoft.EntityFrameworkCore;

namespace Ecommerce.UI.Extentions.Handler
{
    public static class ConfigureContainer
    {
        public static void EnsureMigrationOfContext<T>(this IServiceProvider serviceProvider) where T : DbContext
        {
            using var scope = serviceProvider.CreateScope();
            var migrator = scope.ServiceProvider.GetRequiredService<T>();
            migrator?.Database.Migrate();
        }
    }
}
