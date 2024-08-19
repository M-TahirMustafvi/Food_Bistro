using Food_Bistro.Models.Classes;

namespace Food_Bistro.Models.Interfaces
{
    public interface IUserRepo
    {
        public bool addUser(Users usr);
        public bool authUser(String mail, String pwd);
        public void updateUser(Users user);
        public void deleteUser(int id);
        public IEnumerable<Users> getAllUsers();
        public Users getUserbyEmail(string mail);
    }
}
