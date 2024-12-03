using KatsuShopSolution.Data.Entities;
using KatsuShopSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KatsuShopSolution.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(key => key.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.Status).HasDefaultValue(OrderStatus.InProgress);
            builder.Property(p => p.ShipEmail).IsRequired().HasMaxLength(50).IsUnicode(false);
            builder.Property(x => x.ShipName).IsRequired().HasMaxLength(200);
        }
    }
}
