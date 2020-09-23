using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator
{
    public class ItemCategoryService
    {
        private List<ItemCategory> itemCategories;

        public ItemCategoryService()
        {
            itemCategories = new List<ItemCategory>();
        }

        public void AddNewCategory(int id, string categoryName)
        {
            ItemCategory itemCategory = new ItemCategory() { Id = id, CategoryName = categoryName };
            itemCategories.Add(itemCategory);
        }

        public List<ItemCategory> InitalizeCategory()
        {
            AddNewCategory(1, "Vegetables");
            AddNewCategory(2, "Milk");
            AddNewCategory(3, "Meat");
            AddNewCategory(4, "Fruits");

            return itemCategories;
        }

        
    }
}
