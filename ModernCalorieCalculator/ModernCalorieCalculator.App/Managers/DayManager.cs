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
        public DayManager(DayService dayService, MenuActionService menuActionService)
        {
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
            items.Add(new Item());
            items.Add(new Item());
            items.Add(new Item());
            _dayService.AddDay(new Day(dayId, dayFromUser, userId, items));
        }
    }
}
