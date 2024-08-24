using Food_Bistro.Models.Classes;

namespace Food_Bistro.Models.Interfaces
{
	public interface IProductRepo
	{
		public void addProduct(Product product);
		public void updateProduct(Product product);
		public void removeProduct(int id);
		public Product getProductById(int id);
		public Product getProductByName(String name);
		public IEnumerable<Product> getProductByCategory(String category);
		public IEnumerable<Product> getAllProduct();

    }
}
