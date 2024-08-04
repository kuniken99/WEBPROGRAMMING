using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//to make the context class manageable and readable
//makes it easier to seed or initialize the database
namespace INFT3050.Models
{
    internal class ConfigureOrders : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> entity) 
        {
            // remove cascading delete with Genre
            entity.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
