﻿namespace Turbino.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TurbinoUserConfiguration : IEntityTypeConfiguration<TurbinoUser>
    {
        public void Configure(EntityTypeBuilder<TurbinoUser> builder)
        {
            builder.HasMany(u => u.UserDestinations)
                    .WithOne(ud => ud.User)
                    .HasForeignKey(ud => ud.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Cards)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Claims)
                   .WithOne()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Logins)
                   .WithOne()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Roles)
                   .WithOne()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
