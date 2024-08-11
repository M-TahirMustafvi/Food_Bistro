using Food_Bistro.Models.Classes;

namespace Food_Bistro.Models.Interfaces
{
    public interface InterfaceUsers
    {
        public bool addUser(Users usr);
        public bool authUser(String mail, String pwd);
    }
}
