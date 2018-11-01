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
        public ActionResult ViewPayment()
        {
            int customerId = 1;
            Subscription subscription = db.Subscriptions.Where(s => s.Status.Equals("A")).FirstOrDefault();
            if (subscription == null)
            {
                ViewBag.ERROR_MESSAGE = "Please configure subscription";
                return View("Pay");
            }

            List<Card> cards = db.Cards.Where(c => c.CustomerId == customerId).ToList();
            if (cards == null || cards.Count == 0)
            {
                ViewBag.ERROR_MESSAGE = "Add new card";
            }
            else
            {
                ViewBag.Cards = cards;
            }
            Order order = db.Orders.Include(o => o.OrderDetails.Select(od=>od.Product)).Where(o => o.CustomerId == customerId && o.Status.Equals("PENDING")).FirstOrDefault();
            if (order == null)
            {
                ViewBag.ERROR_MESSAGE = "No order is found.";
            }
            if (order.OrderDetails == null)
            {
                ViewBag.ERROR_MESSAGE = "No order details are found.";
            }
            decimal sum = 0;
            foreach (OrderDetail od in order.OrderDetails)
            {
                sum = sum + od.Quantity * od.Product.Price;
            }
            ViewBag.Total = sum;
            ViewBag.TaxAmount = sum * (decimal)subscription.TaxPercentage / 100;
            ViewBag.TotalAmount = sum + ViewBag.TaxAmount;
            return View("Pay", order);
        }
    }
}