namespace Turbino.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Turbino.Domain.Entities;

    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name).IsRequired();

            builder.HasMany(d => d.Tours)
                    .WithOne(t => t.Destination)
                    .HasForeignKey(t => t.DestinationId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.DestionationUsers)
                .WithOne(d => d.Destination)
                .HasForeignKey(d => d.DestinationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Galery)
                .WithOne(i => i.Destination)
                .HasForeignKey(i => i.DestinationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
