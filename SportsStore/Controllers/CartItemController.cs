using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Controllers
{
    public class CartItemController : Controller
    {
        private ApplicationDbContext _context;
        public CartItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.CartItems.ToList());

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CartItem model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.CartItems.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.CartItems.FirstOrDefault(x => x.CartId == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CartItem model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.CartItems.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.CartItems.FirstOrDefault(x => x.CartId == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Delete(CartItem model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.CartItems.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
