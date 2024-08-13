using Food_Bistro.Models.Classes;

namespace Food_Bistro.Models.Interfaces
{
    public interface IUsers
    {
        public bool addUser(Users usr);
        public bool authUser(String mail, String pwd);
        //private bool authUser(String mail);
    }
}
