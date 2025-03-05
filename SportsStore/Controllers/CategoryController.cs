using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {

            return View(_context.Categories.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Categories.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Categories.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Delete(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Categories.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
