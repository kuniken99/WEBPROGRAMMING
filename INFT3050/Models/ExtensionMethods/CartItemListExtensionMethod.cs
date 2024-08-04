namespace INFT3050.Models
{
    public static class CartItemListExtensions
    {
        //needed to convert CartItem objects to CartItemDTO object
        public static List<CartItemDTO> ToDTO(this List<CartItem> list) =>
            list.Select(ci => new CartItemDTO
            {
                ItemID = ci.Item.ItemID,
                Quantity = ci.Quantity
            }).ToList();
    }
}
