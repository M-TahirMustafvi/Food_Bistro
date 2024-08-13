using Microsoft.AspNetCore.Mvc;

namespace Food_Bistro.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
