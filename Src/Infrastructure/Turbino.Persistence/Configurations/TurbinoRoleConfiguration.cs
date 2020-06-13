namespace Turbino.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.Entities;
    public class TurbinoRoleConfiguration : IEntityTypeConfiguration<TurbinoRole>
    {
        public void Configure(EntityTypeBuilder<TurbinoRole> builder)
        {
            
        }
    }
}
