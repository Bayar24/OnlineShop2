using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.Repositories
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryByID(byte categoryId);
        void InsertCategory(Category book);
        void DeleteCategory(byte categoryID);
        void UpdateCategory(Category category);
        void Save();
    }
}