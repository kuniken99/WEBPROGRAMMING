using System;
using System.ComponentModel.DataAnnotations;

namespace INFT3050.Models
{
    public class Item
    {
        //initialize navigation property collection for one-to-many relationship CustomerOrder
        //initialize navigation property collection for many-to-many relationship OrderItems
        public Item()
        {
            Images = new HashSet<Image>();
            //Orders = new HashSet<Order>();
            OrderItems = new HashSet<OrderItem>();
        }
        
        public int ItemID { get; set; } //primary key
        
        [Required(ErrorMessage = "Please enter a name.")]
        public string ItemName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the type of vitamin.")]
        public string VitaminType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please enter the quantity.")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Please enter a category.")]
        public string Category { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please enter the price.")]
        public double Price { get; set; } = 0;
        public string Company { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }

        public ICollection<Image> Images { get; set; } //navigation property
        public ICollection<OrderItem> OrderItems { get; set; } //navigation property


    }
}
