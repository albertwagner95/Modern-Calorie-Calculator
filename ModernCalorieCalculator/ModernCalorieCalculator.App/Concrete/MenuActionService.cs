using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Managers.Helpers;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernCalorieCalculator.App.Concrete
{
    public class MenuActionService : IMenuAction
    {
        public List<MenuAction> Items { get; set; }

        public MenuActionService()
        { 
            Items = new List<MenuAction>(); 
            Initialize();
        }

        public int AddItem(MenuAction item)
        {
            Items.Add(item);

            return item.Id;
        }

        public List<MenuAction> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem(MenuAction item)
        {
            Items.Remove(item);
        }

        public int UpdateItem(MenuAction item)
        {
            var entity = Items.FirstOrDefault(x => x.Id == item.Id);
            entity = item;
            return entity.Id;

        }
       
        public MenuAction GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(x => x.Id == id);
            return entity;
        }
         
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();

            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }

            return result;
        }

        public void ShowMenu(string menuName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var menuItems = GetMenuActionsByMenuName(menuName);
            foreach (var menuAction in menuItems)
            {
                Console.WriteLine($"{menuAction.Id}. {menuAction.Name}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add new product to database", "Main"));
            AddItem(new MenuAction(2, "All products", "Main"));
            AddItem(new MenuAction(3, "Modify product", "Main"));
            AddItem(new MenuAction(4, "Show item detail a product by Id, Name", "Main"));
            AddItem(new MenuAction(5, "Day manager","Main"));
            AddItem(new MenuAction(6, "Exit", "Main"));

            AddItem(new MenuAction(1, "Vegetables", "AddNewItemMenu"));
            AddItem(new MenuAction(2, "Milk", "AddNewItemMenu"));
            AddItem(new MenuAction(3, "Meat", "AddNewItemMenu"));
            AddItem(new MenuAction(4, "Fruits", "AddNewItemMenu"));
            AddItem(new MenuAction(5, "Back", "AddNewItemMenu"));

            AddItem(new MenuAction(1, "Modify product name", "ModifyItemByIdMenu"));
            AddItem(new MenuAction(2, "Modify product calories 100/g ", "ModifyItemByIdMenu"));
            AddItem(new MenuAction(3, "Modify product quantity fat 100/g", "ModifyItemByIdMenu"));
            AddItem(new MenuAction(4, "Modify product quantity carbohydrates 100/g", "ModifyItemByIdMenu"));
            AddItem(new MenuAction(5, "Modify product quantity proteins 100/g", "ModifyItemByIdMenu"));  
            AddItem(new MenuAction(6, "Back", "ModifyItemByIdMenu"));
            
            AddItem(new MenuAction(1, "Add new day", "DayManager"));
            AddItem(new MenuAction(2, "Add item to day", "DayManager"));
            AddItem(new MenuAction(3, "Show all user days", "DayManager"));

            AddItem(new MenuAction(1, DayManagerHelpers.MealType.Breakfast.ToString(), "KindOfMeal"));
            AddItem(new MenuAction(2, DayManagerHelpers.MealType.SecondBreakfast.ToString(), "KindOfMeal"));
            AddItem(new MenuAction(3, DayManagerHelpers.MealType.Lunch.ToString(), "KindOfMeal"));
            AddItem(new MenuAction(4, DayManagerHelpers.MealType.Dinner.ToString(), "KindOfMeal"));
            AddItem(new MenuAction(5, DayManagerHelpers.MealType.Supper.ToString(), "KindOfMeal"));
            AddItem(new MenuAction(6, DayManagerHelpers.MealType.Snack.ToString(), "KindOfMeal"));

        }
    }



}
