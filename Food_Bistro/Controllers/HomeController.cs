using Microsoft.AspNetCore.Mvc;
using Food_Bistro.Models.Repositories;
using Food_Bistro.Models.Classes;

namespace Food_Bistro.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("SignUp");
        }
        
        [HttpPost]
        public IActionResult Index(Users usr)
        {
            UserRepo repo = new UserRepo();
            if(repo.addUser(usr))
                return View("Index");
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
            //If Name was added as a cooky, it means all cookies
            //were already added
            
            if (!HttpContext.Request.Cookies.ContainsKey("Name"))
            {
                CookieOptions option = new CookieOptions();
                option.Expires = System.DateTime.Now.AddDays(2);

                if(!string.IsNullOrEmpty(Email))
                    HttpContext.Response.Cookies.Append("mail", Email, option);

                if (!string.IsNullOrEmpty(Password))
                    HttpContext.Response.Cookies.Append("pwd", Password, option);
            }

            UserRepo repo = new UserRepo();
            if(repo.authUser(Email, Password))
                return View("Index");

            ViewBag.Message = "*Wrong Authentication Details!";
            return View("LogIn");
        }
    }
}
