namespace INFT3050.Models
{
    public class PaymentViewModel
    {
        public List<Image> Images { get; set; }
        public IEnumerable<CartItem> List { get; set; } = new List<CartItem>();
        //public int Quantity { get; set; }
        public double Subtotal { get; set; }
    }
}
