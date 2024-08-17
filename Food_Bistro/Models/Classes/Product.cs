namespace Food_Bistro.Models.Classes
{
	public class Product
	{
		public int Id { get; set; } = -1;
		public string Name { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public int Price { get; set; } = -1;
		public int Quantity { get; set; } = -1;
		public string Category { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
    }
}
