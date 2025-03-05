using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class ShippingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
