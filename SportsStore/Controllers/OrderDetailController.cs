using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class OrderDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
