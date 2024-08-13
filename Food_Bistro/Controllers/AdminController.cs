using Food_Bistro.Models.Classes;
using Food_Bistro.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Food_Bistro.Controllers
{
    public class AdminController : Controller
    {
		public IActionResult Index()
		{
			return View("SignUp");
		}

		[HttpPost]
		public IActionResult Index(Admins admin)
		{
			if (!HttpContext.Request.Cookies.ContainsKey("mail"))
			{
				if (!string.IsNullOrEmpty(admin.Name))
					HttpContext.Response.Cookies.Append("name", admin.Name);

				if (!string.IsNullOrEmpty(admin.Email))
					HttpContext.Response.Cookies.Append("mail", admin.Email);

			}

			AdminRepo repo = new AdminRepo();
			if (repo.addAdmin(admin))
				return RedirectToAction("Index", "Home");

			ViewBag.Message = "*Email already registered!";
			return View("SignUp");
		}

		[HttpGet]
		public IActionResult LogIn()
		{
			return View();
		}

		[HttpPost]
		public IActionResult LogIn(String Email, String Password)
		{

			if (!HttpContext.Request.Cookies.ContainsKey("mail"))
			{
				CookieOptions option = new CookieOptions();
				option.Expires = System.DateTime.Now.AddDays(2);

				if (!string.IsNullOrEmpty(Email))
					HttpContext.Response.Cookies.Append("mail", Email, option);

			}

			AdminRepo repo = new AdminRepo();
			if (repo.authAdmin(Email, Password))
				return RedirectToAction("Index", "Home");

			ViewBag.Message = "*Wrong Authentication Details!";
			return View("LogIn");
		}
	}
}
