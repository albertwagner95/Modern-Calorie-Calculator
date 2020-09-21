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
                        var itemId = itemService.AddNewItem(keyInfo.KeyChar);

                        var forShow = itemService.Items.Find(x => x.Id == itemId);
                        Console.WriteLine( "Pomyślnie dodano" + forShow.Name + forShow.Id);

                        Console.WriteLine("Wszystie produkty");
                        foreach (var item in itemService.Items)
                        {
                            Console.WriteLine(item.Id + " " + item.Name);
                        }
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
            actionService.AddNewAction(2, "Add product to the selected day", "Main");

            actionService.AddNewAction(1, "Vegetables", "AddNewItemMenu");
            actionService.AddNewAction(2, "Meal", "AddNewItemMenu");
            actionService.AddNewAction(3, "Meat", "AddNewItemMenu");
            actionService.AddNewAction(4, "Fruits", "AddNewItemMenu");

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
