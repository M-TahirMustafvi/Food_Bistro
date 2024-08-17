using Microsoft.AspNetCore.Mvc;
using Food_Bistro.Models.Repositories;
using Food_Bistro.Models.Classes;
using Food_Bistro.Models.Interfaces;

namespace Food_Bistro.Controllers
{
    public class UserController : Controller
    {
		private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

		public IActionResult Index()
        {
            return View("SignUp");
        }

        [HttpPost]
        public IActionResult Index(Users user)
        {
           
                if (!string.IsNullOrEmpty(user.Name))
                    HttpContext.Response.Cookies.Append("name", user.Name);

                if (!string.IsNullOrEmpty(user.Email))
                    HttpContext.Response.Cookies.Append("mail", user.Email);

            

            if (_userRepo.addUser(user))
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("Index", "Home");
            }

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

            if (_userRepo.authUser(Email, Password))
            {
                HttpContext.Session.SetString("UserEmail", Email);
                return RedirectToAction("Index", "Home"); 
            }

            ViewBag.Message = "*Wrong Authentication Details!";
            return View("LogIn");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("LogIn");
        }
    }
}
