﻿namespace Turbino.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Turbino.Domain.Entities;

    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserId).IsRequired();
            builder.Property(r => r.TourId).IsRequired();
        }
    }
}
