namespace Turbino.Application.Common.Interfaces
{    
    using System.Threading.Tasks;
    using System.Threading;
    
    using Microsoft.EntityFrameworkCore;

    using Domain.Entities;

    public interface ITurbinoDbContext
    {
        DbSet<Destination> Destinations { get; set; }

        DbSet<Reservation> Reservations { get; set; }

        DbSet<Tour> Tours { get; set; }

        DbSet<UserDestination> UserDestinations { get; set; } 

        DbSet<TourImage> TourImages { get; set; }

        DbSet<DestinationImage> DestinationImages { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<TeamMember> TeamMembers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}