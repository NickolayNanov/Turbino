namespace Turbino.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Turbino.Domain.Entities;

    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Content).IsRequired();

            builder.HasOne(r => r.Author)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
