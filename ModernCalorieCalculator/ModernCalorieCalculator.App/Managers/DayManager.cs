using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.App.Managers.Helpers;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernCalorieCalculator.App.Managers
{
    public class DayManager
    {
        private IDay _dayService;
        private readonly MenuActionService _actionService;
        private readonly ItemService _itemService;
        public DayManager(DayService dayService, MenuActionService menuActionService, ItemService itemService)
        {
            _itemService = itemService;
            _dayService = dayService;
            _actionService = menuActionService;
        }

        public bool IsUserHasDay(DateTime userDay, int userId)
        {
            var days = _dayService.GetAllUserDays(userId);
            var isDay = days.FirstOrDefault(x => x.UserId == userId);
            if (isDay == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DateTime LoadingDayFromUser()
        {
            DateTime isGoodDayFormat;
            do
            {
                Console.WriteLine("Enter the day you want to enter in format MM/DD/YYYY");
                var day = Console.ReadLine();
                isGoodDayFormat = DayManagerHelpers.ReturnDayFromString(day);
                if (isGoodDayFormat == DateTime.MinValue)
                {
                    Console.WriteLine("Data format is incorrect");
                }
            } while (isGoodDayFormat == DateTime.MinValue);

            return isGoodDayFormat;
        }
        public void AddUserDay(int userId)
        {
            var dayFromUser = LoadingDayFromUser();
            var dayId = _dayService.GetLastId() + 1;
            List<Item> items = new List<Item>();
            _dayService.AddDay(new Day(dayId, dayFromUser, userId, items));
        }
        public string ChooseTypeOfMeal()
        {
            Console.WriteLine("Enter kind of meal");
            var kindOfMeal = _actionService.GetMenuActionsByMenuName("KindOfMeal");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{kindOfMeal[i].Id}. {kindOfMeal[i].Name}");
            }
            var operation = Console.ReadKey();
            switch (operation.KeyChar)
            {
                case '1':
                    return kindOfMeal[0].Name;
                case '2':
                    return kindOfMeal[1].Name;
                case '3':
                    return kindOfMeal[2].Name;
                case '4':
                    return kindOfMeal[3].Name;
                case '5':
                    return kindOfMeal[4].Name;
                case '6':
                    return kindOfMeal[5].Name;
                default:
                    return null;
            }
        }
        public void AddItemToUserDayView(int userId)
        {
            Console.WriteLine("Enter the day you want to add the product");
            var dataFromUser = Console.ReadLine();
            var dayFromUser = DayManagerHelpers.ReturnDayFromString(dataFromUser);
            string kindOfMeal = "";
            do
            {
                kindOfMeal = ChooseTypeOfMeal();
            } while (kindOfMeal == null);

            Console.WriteLine("Enter product Id");
            var idFromUser = Console.ReadLine();
            int productId;
            bool isProductIdLoading = int.TryParse(idFromUser, out productId);

            if (isProductIdLoading == false)
            {
                Console.WriteLine("Product id is incorrect");
            }
            else
            {

                var product = _itemService.GetItemById(productId);
                if (product == null)
                {
                    Console.WriteLine($"Not found product with this ID {productId}");
                }
                else
                {
                    var day = _dayService.AddProductToUserDay(productId, dayFromUser, userId, kindOfMeal);
                    if (day == 0)
                    {
                        Console.WriteLine($"User don't have day {dataFromUser}");
                    }
                    else
                    {
                        Console.WriteLine("Item to day added sucsessed!");
                    }
                }
            }
        }
        public void ShowDayOperations(int userId)
        {
            var operations = _actionService.GetMenuActionsByMenuName("DayManager");
            foreach (var item in operations)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            var operationFromUser = Console.ReadKey();

            switch (operationFromUser.KeyChar)
            {
                case '1':
                    AddUserDay(userId);
                    break;
                case '2':
                    AddItemToUserDayView(userId);
                    break;
                default:
                    Console.WriteLine("Data is incorrect");
                    break;
            }
        }

    }
}
