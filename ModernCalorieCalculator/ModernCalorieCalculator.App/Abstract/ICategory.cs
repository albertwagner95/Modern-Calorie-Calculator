using ModernCalorieCalculator.Domain.Entity;
using System.Collections.Generic;

namespace ModernCalorieCalculator.App.Abstract
{
    public interface ICategory
    {
        List<Category> Categories { get; set; }

        List<Category> GetCategories();

        int AddCategory(Category item);

        void RemoveCategory(Category item);

        Category GetCategoryById(int id);

        string GetCategoryNameById(int id);
    }
}
