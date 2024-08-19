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
            if (_userRepo.addUser(user))
            {
                LogOut();

                if (!string.IsNullOrEmpty(user.Name))
                {
                    HttpContext.Response.Cookies.Append("name", user.Name);
                    HttpContext.Session.SetString("UserName", user.Name);
                }

                if (!string.IsNullOrEmpty(user.Email))
                {
                    HttpContext.Response.Cookies.Append("mail", user.Email);
                    HttpContext.Session.SetString("UserEmail", user.Email);
                }
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
                
            CookieOptions option = new CookieOptions();
            option.Expires = System.DateTime.Now.AddDays(2);
            HttpContext.Response.Cookies.Append("mail", Email, option);



            if (_userRepo.authUser(Email, Password))
            {
                Users curr = _userRepo.getUserbyEmail(Email);
                LogOut();
                if (!string.IsNullOrEmpty(Email))
                {
                    HttpContext.Response.Cookies.Append("mail", Email, option);
                    HttpContext.Session.SetString("UserEmail", Email);
                }
            
                HttpContext.Session.SetString("UserName",curr.Name);
                if (curr.Role == "admin")
                    return RedirectToAction("Index", "Admin");
                
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
