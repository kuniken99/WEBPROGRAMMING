namespace INFT3050.Models
{
    // Trying to store a Book object in session can cause problems because the JSON 
    // serialization done in SessionExtensionMethods.cs can create circular references
    // as the serializer tries to follow all the navigation properties. You can decorate
    // those properties with the [JsonIgnore] attribute, but you can end up with that
    // scattered all around. Another way, shown here, is to create a DTO class with the 
    // data needed for the cart. 
    public class ItemDTO
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public double Price { get; set; }

        //default constructor (required for model binding)
        public ItemDTO() { }

        //overloaded constructor that accepts Item object
        public ItemDTO(Item item)
        {
            ItemID = item.ItemID;
            ItemName = item.ItemName;
            Price = item.Price;
        }
    }
}
