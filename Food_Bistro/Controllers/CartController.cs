using Microsoft.AspNetCore.Mvc;
using Food_Bistro.Models.Classes;
using Food_Bistro.Models.Repositories;
using System.Text.Json;
using Food_Bistro.Models.Interfaces;

namespace Food_Bistro.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepo _productRepo= new ProductRepo();
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult AddToCart(int id)
        {
            Product product = _productRepo.getProductById(id);
            if (product != null)
            {
                var cart = GetCart();
                var cartItem = cart.FirstOrDefault(c => c.product.Id == id);
                if (cartItem == null)
                {
                    cartItem = new CartItem {
                        product = product,
                        CartQuantity = 1,
                    };
                    cart.Add(cartItem);
                }
                else
                {
                    cartItem.CartQuantity++;
                }
                saveCart(cart);
            }
                
            return View("Index");
        }

        private List<CartItem>? GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
                return new List<CartItem>();

            return JsonSerializer.Deserialize<List<CartItem>>(cartJson);
        }

        private void saveCart(List<CartItem> cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString("Cart", cartJson);
        }
    }
}
