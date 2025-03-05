using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult List(string category, int productPage = 1)
        {
            return View();
        }
    }
}
