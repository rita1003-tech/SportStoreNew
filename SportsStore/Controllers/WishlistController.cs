using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class WishlistController : Controller
    {
        private ApplicationDbContext _context;
        public WishlistController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Wishlists.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Wishlist model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Wishlists.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Wishlists.FirstOrDefault(x => x.WishlistId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Wishlist model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Wishlists.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Wishlists.FirstOrDefault(x => x.WishlistId == id);
            if (model != null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Wishlist model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            _context.Wishlists.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
