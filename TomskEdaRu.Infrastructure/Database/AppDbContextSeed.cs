using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TomskEdaRu.Infrastructure.Database
{
    public static class AppDbContextSeed
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                await context.Database.MigrateAsync();
            }
        }
    }
}