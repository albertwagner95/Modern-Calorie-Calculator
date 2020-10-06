using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ModernCalorieCalculator.App.Concrete
{
    class CategoryService : ICategory
    {
        public List<Category> Categories { get; set; }

        public CategoryService()
        {
            Categories = new List<Category>();
            Initialize();
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

        private void Initialize()
        {
            Categories.Add(new Category(1, "Meet"));
            Categories.Add(new Category(2, "Vegetables"));
        }
    }
}
