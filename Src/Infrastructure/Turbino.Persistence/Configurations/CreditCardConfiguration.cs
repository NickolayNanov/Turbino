using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Turbino.Domain.Entities;

namespace Turbino.Persistence.Configurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardNumber).IsRequired();
            builder.Property(c => c.Cvc).IsRequired();
            builder.Property(c => c.CardOwner).IsRequired();

            builder.HasOne(c => c.User).WithMany(u => u.Cards).HasForeignKey(c => c.UserId);
        }
    }
}
