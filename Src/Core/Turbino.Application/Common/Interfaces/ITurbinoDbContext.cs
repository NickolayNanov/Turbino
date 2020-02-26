namespace Turbino.Application.Common.Interfaces
{    
    using System.Threading.Tasks;
    using System.Threading;
    
    using Microsoft.EntityFrameworkCore;

    using Domain.Entities;

    public interface ITurbinoDbContext
    {
         DbSet<Manager> Managers { get; set; }

        DbSet<TurbinoUser> TurbinoUsers { get; set; }

        DbSet<TurbinoRole> TurbinoRoles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}