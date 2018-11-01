using OnlineShop.Context;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace OnlineShop.Controllers
{
    public class PaymentController : Controller
    {
        private OnlineShopContext db = new OnlineShopContext();
        // GET: Payment
        public ActionResult View()
        {
            int customerId = 1;
            List<Card> cards = db.Cards.Where(c => c.CustomerId == customerId).ToList();
            if (cards == null || cards.Count == 0)
            {
                ViewBag.ERROR_MESSAGE = "Add new card";
            }
            else
            {
                ViewBag.Cards = cards;
            }
            Order order = db.Orders.Include(o => o.OrderDetails).Where(o => o.CustomerId == customerId && o.Status.Equals("PENDING")).FirstOrDefault();
            if (order == null)
            {
                ViewBag.ERROR_MESSAGE = "No order found.";
            }

            return View("Pay",order);
        }
    }
}