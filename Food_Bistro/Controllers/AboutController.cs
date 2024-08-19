using Microsoft.AspNetCore.Mvc;

namespace Food_Bistro.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
