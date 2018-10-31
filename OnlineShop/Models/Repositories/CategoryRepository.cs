using OnlineShop.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private OnlineShopContext onlineShopContext;
        public CategoryRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }
        public IEnumerable<Category> GetCategories() => onlineShopContext.Category.ToList();
        public Category GetCategoryByID(byte categoryId) => onlineShopContext.Category.Find(categoryId);
        public void InsertCategory(Category category) => onlineShopContext.Category.Add(category);
        public void UpdateCategory(Category category) => onlineShopContext.Entry(category).State = EntityState.Modified;
        public void Save() => onlineShopContext.SaveChanges();
        public void DeleteCategory(byte categoryID)
        {
            Category category = onlineShopContext.Category.Find(categoryID);
            onlineShopContext.Category.Remove(category);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    onlineShopContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}