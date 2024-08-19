//using Food_Bistro.Models.Classes;
//using Food_Bistro.Models.Interfaces;
//using Microsoft.Data.SqlClient;

//namespace Food_Bistro.Models.Repositories
//{
//	public class AdminRepo : IAdminRepo
//	{
//		private readonly string _conStr = "Data Source=(localdb)\\ProjectModels;Initial Catalog=FoodBistro;Integrated Security=True;Connect Timeout=30;";
//		public AdminRepo(string _conStr)  { }


//		public bool AuthAdmin(string email, string password)
//		{
//			using (SqlConnection con = new SqlConnection(_conStr))
//			{
//				con.Open();
//				string query = "SELECT COUNT(1) FROM Admins WHERE Email = @Email AND Password = @Password";

//				using (SqlCommand cmd = new SqlCommand(query, con))
//				{
//					cmd.Parameters.AddWithValue("@Email", email);
//					cmd.Parameters.AddWithValue("@Password", password);

//					int count = (int)cmd.ExecuteScalar();
//					return count > 0;
//				}
//			}
//		}

//		//public bool Add(Admins admin)
//		//{
//		//	if (!AuthUser(admin.Email))
//		//	{
//		//		Add(admin);
//		//		return true;
//		//	}
//		//	else
//		//	{
//		//		return false;
//		//	}
//		//}

//		private bool AuthUser(string email)
//		{
//			using (SqlConnection con = new SqlConnection(_conStr))
//			{
//				con.Open();
//				string query = "SELECT COUNT(1) FROM Admins WHERE Email = @Email";

//				using (SqlCommand cmd = new SqlCommand(query, con))
//				{
//					cmd.Parameters.AddWithValue("@Email", email);

//					int count = (int)cmd.ExecuteScalar();
//					return count > 0;
//				}
//			}
//		}
//	}
//}
