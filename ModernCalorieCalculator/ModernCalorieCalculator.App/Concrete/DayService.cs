using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernCalorieCalculator.App.Concrete
{
    public class DayService : IDay
    {
        public List<Day> Days { get; set; }
        private IUser _userSerice;
        public DayService(IUser userService)
        {
            _userSerice = userService;
            Days = new List<Day>();
        }
        public int AddDay(Day item)
        {
            Days.Add(item);
            return (item.Id);
        }

        public Day GetDayByDateAndUserId(DateTime date, int userId)
        {
            if (date != null && userId > 0)
            {
                var day = Days.FirstOrDefault(x => x.UserDay == date && x.UserId == userId);
                return day;
            }
            else
            {
                return null;
            }
        }

        public Day GetDayById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Day> GetDaysBetweenTwoDates()
        {
            throw new NotImplementedException();
        }

        public List<Day> GetUserDates(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveDay(Day item)
        {
            throw new NotImplementedException();
        }

        public List<Day> GetAllUserDays(int userId)
        {
            var isUser = _userSerice.GetUserById(userId);
            List<Day> userDays = new List<Day>();
            if (isUser != null)
            {
                userDays = Days.Where(x => x.UserId == isUser.Id).ToList();
                return userDays;
            }
            return null;
        }
    }
}
