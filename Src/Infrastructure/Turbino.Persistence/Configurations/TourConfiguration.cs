using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Turbino.Domain.Entities;

namespace Turbino.Persistence.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.TourType).IsRequired();

            builder.HasOne(t => t.Destination)
                .WithMany(d => d.Tours)
                .HasForeignKey(t => t.DestinationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Galery)
                .WithOne(i => i.Tour)
                .HasForeignKey(i => i.TourId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
