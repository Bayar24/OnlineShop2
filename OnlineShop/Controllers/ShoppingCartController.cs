using OnlineShop.Context;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Collections;

namespace OnlineShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public class OrderRequest
        {
            public string ProductId { get; set; }
            public string Quantity { get; set; }
        }
        private OnlineShopContext db = new OnlineShopContext();
        [HttpPost]
        public JsonResult Add(OrderRequest orderRequest)
        {
            long prodId = Convert.ToInt64(orderRequest.ProductId);
            int quantity = Convert.ToInt32(orderRequest.Quantity);
            int itemsCount = 1;
            if (Session["shoppingCart"] == null)
            {
                Dictionary<long, int> orderList = new Dictionary<long, int>();
                orderList.Add(prodId, quantity);
                Session["shoppingCart"] = orderList;
            }
            else
            {
                Dictionary<long, int> orderList = (Dictionary<long, int>)Session["shoppingCart"];
                if (orderList.ContainsKey(prodId))
                {
                    orderList[prodId] += quantity;
                }
                else
                {
                    orderList.Add(prodId, quantity);
                }
                Session["shoppingCart"] = orderList;
                itemsCount = orderList.Count;
            }
            return Json(itemsCount, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get()
        {
            ViewBag.Categories = db.Category.ToList<Category>();

            if (Session["shoppingCart"] == null)
            {
                return View("ViewCart");
            }

            Dictionary<long, int> cartItems = (Dictionary<long, int>)Session["shoppingCart"];
            decimal total = 0;
            List<Product> products = new List<Product>();
            foreach (long productId in cartItems.Keys)
            {
                Product p = db.Products.Find(productId);
                total += p.Price * (decimal)cartItems[productId];
                products.Add(p);
            }

            ViewBag.Products = products;
            ViewBag.CartItems = cartItems;
            ViewBag.Total = total;

            return View("ViewCart");
        }
        public ActionResult Purchase()
        {
            //User user = SessionUtil.getUser();
            //if (user == null)
            //{
            //    return "redirect:/loginpage";
            //}
            //Integer userId = user.getCustomer().getCustomerId();
            int customerId = 1;
            if (Session["shoppingCart"] == null)
            {
                return View();
            }
            bool isNew = false;
            Order order = db.Orders.Include(o => o.OrderDetails).Where(p => p.Status.Equals("PENDING") && p.CustomerId == customerId).FirstOrDefault();
            if (order == null)
            {
                order = new Order();
                order.CustomerId = customerId;
                order.OrderDate = DateTime.Today;
                order.Status = "PENDING";
                order.OrderDetails = new List<OrderDetail>();
                isNew = true;
            }
            else
            {
                db.OrderDetails.RemoveRange(order.OrderDetails);
            }
            
            Dictionary<long, int> orderDetailList = (Dictionary<long, int>)Session["shoppingCart"];
            foreach (long productId in orderDetailList.Keys)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.ProductId = productId;
                order.OrderDetails.Add(new OrderDetail { ProductId = productId, Quantity = orderDetailList[productId] });
            }
            if (isNew)
            {
                db.Orders.Add(order);
            }
            foreach (OrderDetail orderDetail in order.OrderDetails)
            {
                db.OrderDetails.Add(orderDetail);
            }
            db.SaveChanges();
            return RedirectToAction("ViewPayment", "Payment");
        }
    }
}