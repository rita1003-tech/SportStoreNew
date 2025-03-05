using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using System.Collections.Generic;

namespace SportsStore.Controllers
{
    public class CartItemController : Controller
    {
        public ActionContext Context;
        public CartItemController(ActionContext context)
        {
            Context = context;
        }
        public ActionResult Index()
        {

            return View();
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
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Detail()



    }
}
