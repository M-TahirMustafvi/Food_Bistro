using Microsoft.AspNetCore.Mvc;

namespace Food_Bistro.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("SignUp");
        }
        
        [HttpPost]
        public IActionResult Index(string Name, string Mail, string Pwd)
        {
            return View("Index");
        }
    }
}
