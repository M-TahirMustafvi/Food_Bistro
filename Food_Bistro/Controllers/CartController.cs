using Microsoft.AspNetCore.Mvc;

namespace Food_Bistro.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
