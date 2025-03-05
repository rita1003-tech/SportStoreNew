using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
