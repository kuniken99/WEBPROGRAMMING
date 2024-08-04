using System.Text.Json.Serialization;

namespace INFT3050.Models
{
    // Instances of this class are stored in session after being converted to a 
    // JSON string. Since the readonly Subtotal property doesn't need to be
    // stored, it's decorated with the [JsonIgnore] attribute so it will 
    // be skipped when the JSON string is created.
    public class CartItem
    {
        public ItemDTO Item { get; set; } = new ItemDTO();
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => Item.Price * Quantity;
    }
}
