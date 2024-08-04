using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFT3050.Models
{
    public class Order
    {
        //initialize navigation property collection for many-to-many relationship OrderItems
        public Order() => OrderItems = new HashSet<OrderItem>();
        public int OrderID { get; set; } //primary key
        public string UserID { get; set; } //foreign key need to do this for entity relationships
        //for one to many (customerOrder) must add a navigation property then add hashset in the customers table
        public DateTime Date { get; set; }
        public int Status { get; set; } //Determines the status of the order: 1 = processing, 2 = delivered, 0 = failed to deliver

        public double OrderHistorySubtotal { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } //navigation property

        [NotMapped]
        public User Customer { get; set; } = null!; //navigation property
        

    }
}
