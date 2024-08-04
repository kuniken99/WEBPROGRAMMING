using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
namespace INFT3050.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }

        //[ForeignKey("Item")]
        public int ItemID { get; set; }

        //[ForeignKey("Order")]
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double OrderItemStubtotal { get; set; }
        public Item item { get; set; } = null!;
        
        public Order order { get; set; } = null!;

    }
}
