using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TomskEdaRu.Domain.Entities;
using TomskEdaRu.Logic.Common.ExternalServices.Database;

namespace TomskEdaRu.Infrastructure.Database
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        ///     Trim for string properties
        /// </summary>
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker?.Entries();

            if (entries == null)
            {
                return;
            }

            foreach (var entry in entries)
            {
                var propertyValues =
                    entry.CurrentValues.Properties.Where(p =>
                        p.ClrType == typeof(string));

                foreach (var property in propertyValues)
                {
                    if (entry.CurrentValues[property.Name] != null)
                    {
                        entry.CurrentValues[property.Name] =
                            entry.CurrentValues[property.Name].ToString().Trim();
                    }
                }
            }
        }
    }
}