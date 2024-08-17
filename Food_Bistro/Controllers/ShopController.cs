using Food_Bistro.Models.Classes;
using Food_Bistro.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Food_Bistro.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            ProductRepo productsRepo = new ProductRepo();

            return View(productsRepo.getAllProduct());
        }
        
        public IActionResult ProductDetails()
        {
            return View();
        }

    }
}
