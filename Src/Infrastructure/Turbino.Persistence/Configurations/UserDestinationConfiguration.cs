namespace Turbino.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Turbino.Domain.Entities;

    public class UserDestinationConfiguration : IEntityTypeConfiguration<UserDestination>
    {
        public void Configure(EntityTypeBuilder<UserDestination> builder)
        {
            builder.HasKey(ud => new { ud.UserId, ud.DestinationId });
        }
    }
}
