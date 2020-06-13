namespace Turbino.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Turbino.Domain.Entities;

    public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.HasKey(tm => tm.Id);

            builder.Property(tm => tm.FullName).IsRequired();
            builder.Property(tm => tm.JobTitle).IsRequired();
            builder.Property(tm => tm.ProfilePictureUrl).IsRequired();
        }
    }
}
