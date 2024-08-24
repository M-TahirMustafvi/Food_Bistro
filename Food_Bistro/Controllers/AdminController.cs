using Food_Bistro.Models.Classes;
using Food_Bistro.Models.Interfaces;
using Food_Bistro.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Food_Bistro.Controllers
{
	public class AdminController : Controller
	{
		//private readonly IAdminRepo _adminRepo;

		//public AdminController(IAdminRepo adminRepo)
		//{
		//	_adminRepo = adminRepo;
		//}
        public IActionResult Index()
        {
            ProductRepo productRepo = new ProductRepo();
            return View(productRepo.getAllProduct());
        }


		public IActionResult AddProduct()
		{
			return View();
		}


		[HttpPost]
		public IActionResult AddProduct(Product product)
		{
			ProductRepo productsRepo = new ProductRepo();
			productsRepo.addProduct(product);
			Console.WriteLine($"Producut url is: {product.ImgUrl}");
			return View("Index",productsRepo.getAllProduct());
		}


		public IActionResult DeleteProduct(int id)
		{
            ProductRepo productsRepo = new ProductRepo();
			productsRepo.removeProduct(id);
            return View("Index", productsRepo.getAllProduct());
		}

		public IActionResult EditProduct(int id)
		{
            ProductRepo product = new ProductRepo();
            
            return View("EditProduct", product.getProductById(id));
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            ProductRepo productsRepo = new ProductRepo();
            productsRepo.updateProduct(product);
            return View("Index", productsRepo.getAllProduct());
        }
    };
}
