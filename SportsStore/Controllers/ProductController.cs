using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers {

    public class ProductController : Controller {
        private IProductRepository repository;
        private ApplicationDbContext _context;
        public int PageSize = 4;
        public ProductController(ApplicationDbContext context,IProductRepository repo)
        {
            _context = context;   
            repository = repo;
        }

        public ActionResult List(string category, int productPage = 1)
        {
            var productsListViewModel = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(productsListViewModel); 
        }



        public ActionResult Index()
        {
            var products = _context.Products.ToList();  
            return View(products);  
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Products.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Products.FirstOrDefault(x => x.ProductID == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Products.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Products.FirstOrDefault(x => x.ProductID == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Delete(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Products.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

