using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Collections.Immutable;
using System.Linq;

namespace SportsStore.Controllers
{
    public class OrderDetailController : Controller
    {
       private ApplicationDbContext _context;

        public OrderDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]

        public ActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(OrderDetail model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.OrderDetails.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.OrderDetails.FirstOrDefault(x => x.OrderDetailId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(OrderDetail model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.OrderDetails.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.OrderDetails.FirstOrDefault(x => x.OrderDetailId == id);
            if (model != null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(OrderDetail model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.OrderDetails.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
