using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class PaymentController : Controller
    {
       private ApplicationDbContext _context;
        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index ()
        {
            return View(_context.Payments.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Payment model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Payments.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit (int id)
        {
            var model = _context.Payments.FirstOrDefault(x => x.PaymentId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Payment model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Payments.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Payments.FirstOrDefault(x => x.PaymentId == id);
            if (model != null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Payment model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            _context.Payments.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




              
    }
}
