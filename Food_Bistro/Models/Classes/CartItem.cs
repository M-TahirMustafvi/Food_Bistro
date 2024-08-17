namespace Food_Bistro.Models.Classes
{
    public class CartItem
    {
        public Product? product { get; set; } = null;
        public int CartQuantity { get; set; } = -1;
    }
}
