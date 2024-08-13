using Food_Bistro.Models.Classes;

namespace Food_Bistro.Models.Interfaces
{
	public interface IAdmins
	{
		public bool addAdmin(Admins admin);
		public bool authAdmin(String mail, String pwd);
	}
}
