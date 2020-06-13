namespace Turbino.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.Entities;

    public class TurbinoUserConfiguration : IEntityTypeConfiguration<TurbinoUser>
    {
        public void Configure(EntityTypeBuilder<TurbinoUser> builder)
        {
            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.Author)
                .HasForeignKey(u => u.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.UserDestinations)
                    .WithOne(ud => ud.User)
                    .HasForeignKey(ud => ud.UserId)
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
