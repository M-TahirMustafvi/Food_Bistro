using Microsoft.AspNetCore.Mvc;
using Food_Bistro.Models.Repositories;
using Food_Bistro.Models.Classes;

namespace Food_Bistro.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("SignUp");
        }

        [HttpPost]
        public IActionResult Index(Users usr)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("mail"))
            {
                if (!string.IsNullOrEmpty(usr.Name))
                    HttpContext.Response.Cookies.Append("name", usr.Name);

                if (!string.IsNullOrEmpty(usr.Email))
                    HttpContext.Response.Cookies.Append("mail", usr.Email);

            }

            UserRepo repo = new UserRepo();
            if (repo.addUser(usr))
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

            UserRepo repo = new UserRepo();
            if (repo.authUser(Email, Password))
                return RedirectToAction("Index", "Home");

            ViewBag.Message = "*Wrong Authentication Details!";
            return View("LogIn");
        }
    }
}
