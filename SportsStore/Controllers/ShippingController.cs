using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class ShippingController : Controller
    {
        private ApplicationDbContext _context;
        public ShippingController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Shippings.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Shipping model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Shippings.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Shippings.FirstOrDefault(x => x.ShippingId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Shipping model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Shippings.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Shippings.FirstOrDefault(x => x.ShippingId == id);
            if (model != null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Shipping model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            _context.Shippings.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
