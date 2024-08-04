namespace INFT3050.Models
{
    public class OrderHistoryDetailViewModel
    {
        public Order OrderHistory {  get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<Image> OrderImages { get; set; }
        public List<Item> Items { get; set; }
    }
}
