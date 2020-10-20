using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ModernCalorieCalculator.App.Concrete
{
    public class CategoryService : ICategory
    {
        public List<Category> Categories { get; set; }

        public CategoryService()
        {
            Categories = new List<Category>();
            InitializeBasicCategories();
        }

        public int AddCategory(Category category)
        {
            Categories.Add(category);
            return category.CategoryId;
        }

        public List<Category> GetCategories()
        {
            return Categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = Categories.FirstOrDefault(x => x.CategoryId == id);
            return category;
        }

        public void RemoveCategory(Category item)
        {
            Categories.Remove(item);

        }

        private void InitializeBasicCategories()
        {
            Categories.Add(new Category(1, "Meat"));
            Categories.Add(new Category(2, "Vegetables"));
            Categories.Add(new Category(3, "Diary"));
            Categories.Add(new Category(4, "Confections"));
            Categories.Add(new Category(5, "Water"));
            Categories.Add(new Category(6, "Fruits"));
            Categories.Add(new Category(7, "Grains"));
            Categories.Add(new Category(8, "Other"));
        }

        public string GetCategoryNameById(int id)
        {
            var categoryName = Categories.FirstOrDefault(x => x.CategoryId == id);
            return categoryName.CategoryName;
        }
    }
}
