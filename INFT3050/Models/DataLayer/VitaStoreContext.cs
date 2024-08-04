using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace INFT3050.Models
{
    public class VitaStoreContext : IdentityDbContext <User>
    {
        public VitaStoreContext(DbContextOptions<VitaStoreContext> options) : base(options) 
        { }
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        //public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        //public DbSet<Staff> StaffMembers { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConfigureItems());
            modelBuilder.ApplyConfiguration(new ConfigureImages());
            //modelBuilder.ApplyConfiguration(new ConfigureCustomers());
            //modelBuilder.ApplyConfiguration(new ConfigureStaff());
            modelBuilder.ApplyConfiguration(new ConfigureOrders());
            modelBuilder.ApplyConfiguration(new ConfigureOrderItems());
            modelBuilder.ApplyConfiguration(new ConfigureBrands());
       
        }
    }
}
