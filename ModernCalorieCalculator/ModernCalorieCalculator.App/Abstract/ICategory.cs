using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.App.Abstract
{
    interface ICategory
    {
        List<Category> Categories { get; set; }

        List<Category> GetCategories();

        int AddCategory(Category item);

        void RemoveCategory(Category item);

        Category GetCategoryById(int id);

        private void Initialize();
    }
}
