using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.App.Abstract
{
    public interface IDay
    {
        List<Day> Days { get; set; }

        List<Day> GetDaysBetweenTwoDates();

        int AddDay(Day item);

        void RemoveDay(Day item);

        Day GetDayById(int id);

        Day GetDayByDateAndUserId(DateTime date, int userId);

        List<Day> GetAllUserDays(int userId);
    }
}
