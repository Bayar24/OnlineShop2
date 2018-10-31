using OnlineShop.Context;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private OnlineShopContext db = new OnlineShopContext();
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).ToList<Product>();
            ViewBag.Products = products;
            return View(db.Category.ToList<Category>());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}