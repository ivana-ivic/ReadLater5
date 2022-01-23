﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
