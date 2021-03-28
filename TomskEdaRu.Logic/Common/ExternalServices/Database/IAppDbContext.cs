using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TomskEdaRu.Domain.Entities;

namespace TomskEdaRu.Logic.Common.ExternalServices.Database
{
    public interface IAppDbContext
    {
        DbSet<Animal> Animals { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}