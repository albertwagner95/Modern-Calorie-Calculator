using ModernCalorieCalculator.App;
using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.App.Managers;
using System;


namespace ModernCalorieCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Today is " + DateTime.Today.ToShortDateString());
            Console.WriteLine("\nWelcome in Modern Calories Calculator \n");

            ItemService itemService = new ItemService();
            MenuActionService actionService = new MenuActionService();
            CategoryService categoryService = new CategoryService();
            UserService userService = new UserService();
            DayService dayService = new DayService(userService, itemService);

            UserManager userManager = new UserManager(userService);
            ItemManager itemManager = new ItemManager(actionService, itemService, categoryService);
            DayManager dayManager = new DayManager(dayService, actionService, itemService);

            var isLogin = 0;

            while (isLogin == 0)
            {
                isLogin = userManager.Start();
                Console.Clear();
            }

            if (isLogin > 0)
            {
                var user = userService.GetUserById(isLogin);
                Console.WriteLine($"You are logged in as {user.Name} {user.LastName}\n");

                while (isLogin > 0)
                {
                    actionService.ShowMenu("Main");
                    var operation = Console.ReadKey();
                    Console.Clear();
                    switch (operation.KeyChar)
                    {
                        case '1':
                            itemManager.AddNewItem();
                            break;
                        case '2':

                            Console.WriteLine(itemService.GetAllItems().ToStringTable(new[] { "Id", "Name", "Kcal", "Fat", "Protein", "Carbo", "Cost", "Category" },
                                x => x.Id,
                                x => x.Name,
                                x => x.KcalPerOneHounderGrams,
                                x => x.QuantityFatsPOHG,
                                x => x.QuantityProteinsPOHG,
                                x => x.QuantityCarbohydratesPOHG,
                                x => x.ProductCost,
                                x => x.CategoryName));
                            break;
                        case '3':
                            itemManager.updateitem();
                            break;
                        case '4':
                            itemManager.ShowOneProduct();
                            break;
                        case '5':
                            dayManager.ShowDayOperations(isLogin);
                            break;
                        case '6':
                            isLogin = 0;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Action you entered does not exist");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
    }
}
