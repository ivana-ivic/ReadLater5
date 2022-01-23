using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private ReadLaterDataContext _ReadLaterDataContext;
        public CategoryService(ReadLaterDataContext readLaterDataContext) 
        {
            _ReadLaterDataContext = readLaterDataContext;            
        }

        public Category CreateCategory(Category category)
        {
            _ReadLaterDataContext.Add(category);
            _ReadLaterDataContext.SaveChanges();
            return category;
        }

        public void UpdateCategory(Category category)
        {
            _ReadLaterDataContext.Update(category);
            _ReadLaterDataContext.SaveChanges();
        }

        public List<Category> GetCategories(string userId)
        {
            return _ReadLaterDataContext.Categories.Where(c => c.AspNetUserId == userId).ToList();
        }

        public Category GetCategory(int Id, string userId)
        {
            return _ReadLaterDataContext.Categories.Where(c => c.ID == Id && c.AspNetUserId == userId).FirstOrDefault();
        }

        public Category GetCategory(string Name, string userId)
        {
            return _ReadLaterDataContext.Categories.Where(c => c.Name == Name && c.AspNetUserId == userId).FirstOrDefault();
        }

        public void DeleteCategory(Category category)
        {
            _ReadLaterDataContext.Categories.Remove(category);
            _ReadLaterDataContext.SaveChanges();
        }
    }
}
