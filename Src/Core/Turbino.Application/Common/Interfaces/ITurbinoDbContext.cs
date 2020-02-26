namespace Turbino.Application.Common.Interfaces
{    
    using System.Threading.Tasks;
    using System.Threading;
    
    using Microsoft.EntityFrameworkCore;

    using Domain.Entities;

    public interface ITurbinoDbContext
    {
         //DbSet<Manager> Managers { get; set; }

        DbSet<CreditCard> CreditCards { get; set; }

        DbSet<Destination> Destinations { get; set; }

        DbSet<Reservation> Reservations { get; set; }

        DbSet<Tour> Tours { get; set; }

        DbSet<UserDestination> UserDestinations { get; set; } 

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}