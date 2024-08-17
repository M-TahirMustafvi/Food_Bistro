using Food_Bistro.Models.Classes;
using Food_Bistro.Models.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Food_Bistro.Models.Repositories
{
	public class ProductRepo : IProductRepo
	{
		string conStr = "Data Source=(localdb)\\ProjectModels;Initial Catalog=FoodBistro;Integrated Security=True;";
		public void addProduct(Product product)
		{
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "INSERT INTO product (Name, Price, ImgUrl, Quantity, Category, Description) " +
                               "VALUES (@Name, @Price, @ImgUrl, @Quantity, @Category, @Description)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@ImgUrl", product.ImgUrl);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@Category", product.Category);
                    cmd.Parameters.AddWithValue("@Description", product.Description);

                    con.Open();
                    cmd.ExecuteNonQuery(); 
                }
            }
        }

		public IEnumerable<Product> getAllProduct()
		{
			var product = new List<Product>();
			using (SqlConnection con = new SqlConnection(conStr))
			{
				string query = "SELECT * FROM product";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					con.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Product curr = new Product();
							curr.Name = reader.GetString(1);
							curr.Price = reader.GetInt32(2);
							curr.ImgUrl = reader.GetString(3);
							curr.Quantity = reader.GetInt32(4);
							curr.Category = reader.GetString(5);
							curr.Description = reader.GetString(6);
							product.Add(curr);
						}
					}
				}
			}
			return product;
		}

		public IEnumerable<Product> getProductByCategory(string category)
		{
            var product = new List<Product>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
					string query = "SELECT * FROM product WHERE category = @category";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@category", category);
					con.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Product curr = new Product();
							curr.Name = reader.GetString(1);
							curr.Price = reader.GetInt32(2);
							curr.ImgUrl = reader.GetString(3);
							curr.Quantity = reader.GetInt32(4);
							curr.Category = reader.GetString(5);
							curr.Description = reader.GetString(6);
							product.Add(curr);
						}
					}
				}
			}
			return product;
		}

		public Product getProductById(int id)
		{
            Product product = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT * FROM product WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Name = reader.GetString(1),
                                Price = reader.GetInt32(2),
                                ImgUrl = reader.GetString(3),
                                Quantity = reader.GetInt32(4),
                                Category = reader.GetString(5),
                                Description = reader.GetString(6)
                            };
                        }
                    }
                }
            }
            return product;
        }

		public void removeProduct(int id)
		{
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "DELETE FROM product WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery(); 
                }
            }
        }

		public void updateProduct(Product product)
		{
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "UPDATE product SET Name = @Name, Price = @Price, ImgUrl = @ImgUrl, " +
                                "Quantity = @Quantity, Category = @Category, Description = @Description " +
                                "WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@ImgUrl", product.ImgUrl);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@Category", product.Category);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Id", product.Id); 

                    con.Open();
                    cmd.ExecuteNonQuery(); 
                }
            }
        }
    }
}
