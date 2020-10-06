using ModernCalorieCalculator.App.Concrete;
using System;
using System.Collections.Generic;
using ModernCalorieCalculator.App;
using ModernCalorieCalculator.App.Managers;
using ModernCalorieCalculator.Helpers;
using System.Data;
using ModernCalorieCalculator.Domain.Entity;

namespace ModernCalorieCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Today is " + DateTime.Today.ToShortDateString());
            Console.WriteLine("\nWelcome in Modern Calories Calculator");
            Console.WriteLine("Please enter, what do you want to do?");


            ItemService itemService = new ItemService();
            MenuActionService actionService = new MenuActionService();

            ItemManager itemManager = new ItemManager(actionService, itemService);

            while (true)
            {
                actionService.ShowMenu("Main");

                var operation = Console.ReadKey();

                switch (operation.KeyChar)
                {
                    case '1':
                        itemManager.AddNewItem();
                        break;
                    case '2':

                        Console.WriteLine(itemService.GetAllItems().ToStringTable(new[] { "Id", "Name", "Kcal", "Fat", "Protein", "Carbo", "cost" },
                            x => x.Id,
                            x => x.Name,
                            x => x.KcalPerOneHounderGrams,
                            x => x.QuantityFatsPOHG,
                            x => x.QuantityProteinsPOHG,
                            x => x.QuantityCarbohydratesPOHG,
                            x => x.ProductCost));
                        break;
                    case '3':
                        itemManager.updateitem();
                        break;
                    case '4':
                        itemManager.ShowOneProduct();
                        break;


                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Action you entered does not exist");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }

        }





    }
}
