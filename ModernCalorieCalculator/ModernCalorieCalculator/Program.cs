using System;
using System.Collections.Generic;

namespace ModernCalorieCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Today is " + DateTime.Today.ToShortDateString());
            Console.WriteLine("\nWelcome in Modern Calories Calculator");
            Console.WriteLine("Please enter, what do you want to do?");

            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);

            ItemCategoryService itemCategoryService = new ItemCategoryService();
            var itemCategoryList =  itemCategoryService.InitalizeCategory();

            var mainMenu = actionService.GetMenuActionsByMenuName("Main");
            ItemService itemService = new ItemService();

            while (true)
            {
                ShowMenu(mainMenu);

                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        var keyInfo = itemService.AddNewItemView(actionService);
                        if (keyInfo.KeyChar == '5')
                        {
                            ShowMenu(mainMenu);
                            Console.Clear();
                        }
                        else
                        {
                            var itemId = itemService.AddNewItem(keyInfo.KeyChar);
                            var product = itemService.Items.Find(x => x.Id == itemId);

                            Console.WriteLine($"Product {product.Name} successfully added.");
                        }
                        break;

                    case '2':
                        var detailsProductId = itemService.DetailItemView();

                        itemService.ShowItemDetails(detailsProductId, itemCategoryList);
                        break;

                    case '3':
                        var modifyMenu = itemService.ModifyItemView(actionService);
                        itemService.ModifyItemBySelectedCategory(modifyMenu.KeyChar, itemCategoryList);
                        //itemService.ShowItemDetails(productIdToModify);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Action you entered does not exist");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }

            //Item item = new Item() { TypeOfMeal = KindOfMeal.Breakfast };
            //Console.WriteLine(item.TypeOfMeal);
        }



        public static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add new product to database", "Main");
            actionService.AddNewAction(2, "Product details", "Main");
            actionService.AddNewAction(3, "Modify product", "Main");
            actionService.AddNewAction(4, "Find a product by Id, Name", "Main");
            actionService.AddNewAction(5, "Exit", "Main");

            actionService.AddNewAction(1, "Vegetables", "AddNewItemMenu");
            actionService.AddNewAction(2, "Milk", "AddNewItemMenu");
            actionService.AddNewAction(3, "Meat", "AddNewItemMenu");
            actionService.AddNewAction(4, "Fruits", "AddNewItemMenu");
            actionService.AddNewAction(5, "Back", "AddNewItemMenu");

            actionService.AddNewAction(1, "Modify product name.", "ModifyItemByIdMenu");
            actionService.AddNewAction(2, "Modify product calories 100/g ", "ModifyItemByIdMenu");
            actionService.AddNewAction(3, "Modify product quantity fat 100/g", "ModifyItemByIdMenu");
            actionService.AddNewAction(4, "Modify product quantity carbohydrates 100/g", "ModifyItemByIdMenu");
            actionService.AddNewAction(5, "Modify product quantity proteins 100/g", "ModifyItemByIdMenu");
            actionService.AddNewAction(6, "Modify product cost", "ModifyItemByIdMenu");
            actionService.AddNewAction(7, "Back", "ModifyItemByIdMenu");

            return actionService;
        }

        public static void ShowMenu(List<MenuAction> mainMenu)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var menuAction in mainMenu)
            {
                Console.WriteLine($"{menuAction.Id}. {menuAction.Name}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;


        }
    }
}
