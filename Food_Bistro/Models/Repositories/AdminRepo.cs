using Food_Bistro.Models.Classes;
using Food_Bistro.Models.Interfaces;
using Microsoft.Data.SqlClient;

namespace Food_Bistro.Models.Repositories
{
	public class AdminRepo : IAdmins
	{
		string conStr = "Data Source=(localdb)\\ProjectModels;Initial Catalog=FoodBistro;Integrated Security=True;Connect Timeout=30";

		#region Login/Signup
		public bool addAdmin(Admins admin)
		{
			if (!authUser(admin.Email))
			{
				using (SqlConnection con = new SqlConnection(conStr))
				{
					con.Open();

					string cmdText = "INSERT INTO Admins (Name, Email, Password) VALUES (@UserName, @Email, @Password)";

					using (SqlCommand cmd = new SqlCommand(cmdText, con))
					{
						cmd.Parameters.AddWithValue("@UserName", admin.Name);
						cmd.Parameters.AddWithValue("@Email", admin.Email);
						cmd.Parameters.AddWithValue("@Password", admin.Password);

						cmd.ExecuteNonQuery();
					}
				}
				return true;
			}
			else
				return false;
		}

		public bool authAdmin(string mail, string pwd)
		{
			using (SqlConnection con = new SqlConnection(conStr))
			{
				con.Open();

				string cmdText = "SELECT COUNT(1) FROM Admins WHERE Email = @mail AND Password = @pwd";

				using (SqlCommand cmd = new SqlCommand(cmdText, con))
				{
					cmd.Parameters.AddWithValue("@mail", mail);
					cmd.Parameters.AddWithValue("@pwd", pwd);

					int userCount = (int)cmd.ExecuteScalar();

					return userCount > 0;
				}
			}
		}

		#endregion


		#region Helper

		private bool authUser(string mail)
		{
			using (SqlConnection con = new SqlConnection(conStr))
			{
				con.Open();

				string cmdText = "SELECT COUNT(1) FROM Admins WHERE Email = @mail";

				using (SqlCommand cmd = new SqlCommand(cmdText, con))
				{
					cmd.Parameters.AddWithValue("@mail", mail);
					int userCount = (int)cmd.ExecuteScalar();

					return userCount > 0;
				}
			}
		}

		#endregion
	}
}
