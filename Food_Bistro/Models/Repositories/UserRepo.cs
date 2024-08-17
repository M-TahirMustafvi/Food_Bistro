using Food_Bistro.Models.Classes;
using Food_Bistro.Models.Interfaces;
using Microsoft.Data.SqlClient;

namespace Food_Bistro.Models.Repositories
{
    public class UserRepo : IUserRepo
    {
        string conStr = "Data Source=(localdb)\\ProjectModels;Initial Catalog=FoodBistro;Integrated Security=True;Connect Timeout=30";

        #region CRUD
        public bool addUser(Users usr)
        {
            if (!authUser(usr.Email))
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    string cmdText = "INSERT INTO Users (Name, Email, Password) VALUES (@UserName, @Email, @Password)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", usr.Name);
                        cmd.Parameters.AddWithValue("@Email", usr.Email);
                        cmd.Parameters.AddWithValue("@Password", usr.Password);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            else
                return false;
        }

        public bool authUser(string mail, string pwd)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string cmdText = "SELECT COUNT(1) FROM Users WHERE Email = @mail AND Password = @pwd";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@pwd", pwd);

                    int userCount = (int)cmd.ExecuteScalar();

                    return userCount > 0;
                }
            }
        }

        public void deleteUser(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string cmdText = "DELETE FROM Users WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Users> getAllUsers()
        {
            List<Users> users = new List<Users>();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string cmdText = "SELECT Id, Name, Email, Password FROM Users";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                Password = reader.GetString(3)
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public Users getUserbyEmail(string mail)
        {
            Users user = null;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string cmdText = "SELECT Id, Name, Email, Password FROM Users WHERE Email = @mail";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@mail", mail);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Users
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                Password = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return user;
        }

        public void updateUser(Users user)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string cmdText = "UPDATE Users SET Name = @UserName, Email = @Email, Password = @Password WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Id", user.Id);

                    cmd.ExecuteNonQuery();
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

                string cmdText = "SELECT COUNT(1) FROM Users WHERE Email = @mail";

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
