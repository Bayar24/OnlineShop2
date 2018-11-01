using OnlineShop.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace OnlineShop.Context
{
    public class OnlineShopContext : DbContext
    {
        public OnlineShopContext()
        {
            Database.Log = s => Debug.WriteLine(s);
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}