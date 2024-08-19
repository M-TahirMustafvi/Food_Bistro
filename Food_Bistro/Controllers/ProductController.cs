using Food_Bistro.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Food_Bistro.Controllers
{
	public class ProductController : Controller
	{
        private readonly IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult Index()
		{
			return View();
		}
	}
}
