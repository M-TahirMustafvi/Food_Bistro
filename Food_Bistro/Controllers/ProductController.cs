using Microsoft.AspNetCore.Mvc;

namespace Food_Bistro.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
