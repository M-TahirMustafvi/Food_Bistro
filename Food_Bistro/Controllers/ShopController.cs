using Microsoft.AspNetCore.Mvc;

namespace Food_Bistro.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
