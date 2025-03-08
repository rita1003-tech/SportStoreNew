using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {

            return View(_context.Orders.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Order model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Orders.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Orders.FirstOrDefault(x => x.OrderId == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Order model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Orders.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Orders.FirstOrDefault(x => x.OrderId == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Delete(Order model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Orders.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
