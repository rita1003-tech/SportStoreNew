using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Extensions;
using SportsStore.Infrastructure;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers {

    public class CartController : Controller {

        private IProductRepository repository;
        private readonly ApplicationDbContext _context;

        public CartController(IProductRepository repo, ApplicationDbContext context) {
            repository = repo;
            _context = context;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndex
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId,
                string returnUrl) {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null) {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart() {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart) {
            HttpContext.Session.SetJson("Cart", cart);
        }
        public IActionResult CartControllerIndex()
        {
            var cart = HttpContext.Session.Get<List<Models.CartItem>>("Cart") ?? new List<Models.CartItem>();
            return View(cart);
        }
        public IActionResult CartControllerAddToCart(int productId)

        {
            var cart = HttpContext.Session.Get<List<Models.CartItem>>("Cart") ?? new List<Models.CartItem>();
            var existingItem = cart.FirstOrDefault(p => p.ProductId == productId);
            if (existingItem == null)
            {
                cart.Add(new Models.CartItem { ProductId = productId, ProductName = "Product" + productId, Quantity = 1 });
            }
            else
            {
                existingItem.Quantity++;
            }

            HttpContext.Session.Set("Cart", cart);
            return RedirectToAction("Index");

        }
       
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }
      
    }
}
