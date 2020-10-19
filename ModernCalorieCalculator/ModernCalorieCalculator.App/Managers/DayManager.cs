using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.App.Managers.Helpers;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernCalorieCalculator;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace ModernCalorieCalculator.App.Managers
{
    public class DayManager
    {

        private IDay _dayService;
        private readonly MenuActionService _actionService;
        private readonly IService _itemService;
        public DayManager(IDay dayService, MenuActionService menuActionService, IService itemService)
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
            var allUserDays = _dayService.GetAllUserDays(userId);
            var isDayInUser = allUserDays.FirstOrDefault(x => x.UserDay.Equals(dayFromUser));

            if (isDayInUser != null)
            {
                Console.WriteLine("You can't enter the same day");
            }
            else
            {
                var dayId = _dayService.GetLastId() + 1;
                _dayService.AddDay(new Day(dayId, dayFromUser, userId));
            }
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

            Console.WriteLine("Enter product Id");
            var idFromUser = Console.ReadLine();
            int productId;
            bool isProductIdLoading = int.TryParse(idFromUser, out productId);

            var typeOfMeal = ChooseTypeOfMeal();

            Console.WriteLine("give me grams");
            var productGramsFromUser = Console.ReadLine();
            decimal productGrams;
            decimal.TryParse(productGramsFromUser, out productGrams);

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
                    var day = _dayService.AddProductToUserDay(productId, dayFromUser, userId, typeOfMeal, productGrams);
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
                case '3':
                    ShowUserDay(userId);
                    break;
                default:
                    Console.WriteLine("Data is incorrect");
                    break;
            }
        }

        private void ShowUserItemsInTypeOfMeal(string typeOfMealName, Day dayToShow)
        {
            Console.WriteLine($"{typeOfMealName} \n");
            Console.WriteLine(dayToShow.DayItems.Where(x => x.TypeOfMeal == typeOfMealName)
                                    .ToStringTable(new[] { "Id", "Name", "Kcal", "Proteins", "Fats", "Carbohydrates" },
                                    x => x.Id,
                                    x => x.Name,
                                    x => x.KcalPerOneHounderGrams,
                                    x => x.QuantityProteinsPOHG,
                                    x => x.QuantityFatsPOHG,
                                    x => x.QuantityFatsPOHG));
        }
        private void ShowUserDay(int userId)
        {
            var userDays = _dayService.GetAllUserDays(userId);
            var dayFromUser = LoadingDayFromUser();
            var dayToShow = userDays.FirstOrDefault(x => x.UserDay == dayFromUser);

            if (dayToShow != null)
            {
                List<Day> dayHelper = new List<Day>();
                dayHelper.Add(dayToShow);
                Console.WriteLine(dayHelper.ToStringTable(new[] { "Id", "Date:", "Day week" },
                                                            x => x.Id,
                                                            x => x.UserDay.ToShortDateString(),
                                                            x => x.UserDay.DayOfWeek));

                ShowUserItemsInTypeOfMeal(DayManagerHelpers.MealType.Breakfast.ToString(), dayToShow);
                ShowUserItemsInTypeOfMeal(DayManagerHelpers.MealType.SecondBreakfast.ToString(), dayToShow);
                ShowUserItemsInTypeOfMeal(DayManagerHelpers.MealType.Lunch.ToString(), dayToShow);
                ShowUserItemsInTypeOfMeal(DayManagerHelpers.MealType.Dinner.ToString(), dayToShow);
                ShowUserItemsInTypeOfMeal(DayManagerHelpers.MealType.Snack.ToString(), dayToShow);
                ShowUserItemsInTypeOfMeal(DayManagerHelpers.MealType.Supper.ToString(), dayToShow);

                ShowDailySummary(dayToShow);
            }
            else
            {
                Console.WriteLine($"User don't have day {dayFromUser.ToShortDateString()}");
            }
        }

        private void ShowDailySummary(Day dayToShow)
        {
            var calorieSummary = DayManagerHelpers.ReturnCalorieSummary(dayToShow.DayItems);
            var fatSummary = DayManagerHelpers.ReturnFatSummary(dayToShow.DayItems);
            var carbohydratesSummary = DayManagerHelpers.ReturnCarbohydratesSummary(dayToShow.DayItems);
            var proteinsSummary = DayManagerHelpers.ReturnProteinsSummary(dayToShow.DayItems);
            var costSummary = DayManagerHelpers.ReturnCostSummary(dayToShow.DayItems);

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Calories:   {calorieSummary}");
            Console.WriteLine($"Fat:   {fatSummary}");
            Console.WriteLine($"Carbohydrates:   {carbohydratesSummary}");
            Console.WriteLine($"Proteins:   {proteinsSummary}");
            Console.WriteLine($"Cost:   {costSummary}");
            Console.WriteLine("---------------------------------------------------");

        }
    }
}
