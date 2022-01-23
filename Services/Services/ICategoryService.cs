using Entity;
using System.Collections.Generic;

namespace Services
{
    public interface ICategoryService
    {
        Category CreateCategory(Category category);
        List<Category> GetCategories(string userId);
        Category GetCategory(int Id, string userId);
        Category GetCategory(string Name, string userId);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
