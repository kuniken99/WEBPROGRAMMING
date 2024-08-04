using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFT3050.Models
{
    internal class ConfigureOrderItems : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity
                .HasOne(oi => oi.item)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(io=>io.ItemID);

            entity
               .HasOne(oi => oi.order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(io => io.OrderID);

        }
    }
}
