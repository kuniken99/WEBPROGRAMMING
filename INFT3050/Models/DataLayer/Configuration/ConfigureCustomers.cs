using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//to make the context class manageable and readable
//makes it easier to seed or initialize the database

namespace INFT3050.Models
{
    internal class ConfigureCustomers : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity) 
        {
            //seed initial data
            entity.HasData(
                new Customer
                {
                    CustomerID = 1,
                    AccountType = 3,
                    Name = "Cus Tomer",
                    Email = "customer01@gmail.com",
                    Address = "123 Bukit Batok 676567, Singapore",
                    MobileNumber = "65688264",
                    Username = "Customer01",
                    Password = "321"
                });
        }
    }
}
