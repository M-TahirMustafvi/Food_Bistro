using Microsoft.AspNetCore.Mvc;
using Food_Bistro.Models.Repositories;
using Food_Bistro.Models.Classes;

namespace Food_Bistro.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
