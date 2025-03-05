using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
