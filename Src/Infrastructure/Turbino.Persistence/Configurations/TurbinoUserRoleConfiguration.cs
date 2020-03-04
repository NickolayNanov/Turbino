using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Turbino.Domain.Entities;

namespace Turbino.Persistence.Configurations
{
    public class TurbinoUserRoleConfiguration : IEntityTypeConfiguration<TurbinoUserRole>
    {
        public void Configure(EntityTypeBuilder<TurbinoUserRole> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}
