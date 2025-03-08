using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class ReviewController : Controller
    {
        private ApplicationDbContext _context;
        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Reviews.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Review model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Reviews.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Reviews.FirstOrDefault(x => x.ReviewId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Review model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Reviews.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Reviews.FirstOrDefault(x => x.ReviewId == id);
            if (model != null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Review model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            _context.Reviews.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
