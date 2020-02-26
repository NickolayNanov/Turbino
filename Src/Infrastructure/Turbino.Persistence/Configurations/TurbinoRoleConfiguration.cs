namespace Turbino.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TurbinoRoleConfiguration : IEntityTypeConfiguration<TurbinoRole>
    {
        public void Configure(EntityTypeBuilder<TurbinoRole> builder)
        {
            
        }
    }
}
