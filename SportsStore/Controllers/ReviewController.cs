using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
