using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;

namespace ModernCalorieCalculator.App.Abstract
{
    public interface IDay
    {
        List<Day> Days { get; set; }

        List<Day> GetDaysBetweenTwoDates();

        int AddDay(Day day);

        void RemoveDay(Day day);

        Day GetDayById(int id);

        Day GetDayByDateAndUserId(DateTime date, int userId);

        List<Day> GetAllUserDays(int userId);

        int AddProductToUserDay(int productId, DateTime dayDate, int userId, string typeOfMeal, decimal grams);

        int GetLastId();
    }
}
