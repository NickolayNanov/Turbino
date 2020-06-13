namespace Turbino.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Turbino.Domain.Entities;
    public class TurbinoUserRoleConfiguration : IEntityTypeConfiguration<TurbinoUserRole>
    {
        public void Configure(EntityTypeBuilder<TurbinoUserRole> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}
