using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ModernCalorieCalculator.App.Managers.Helpers
{
   public class DayManagerHelpers
    {
        /// <summary>
        /// If format day is incorrect, method return min day.
        /// Good format date is MM/DD/YYYY
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Date from user if is valid, else min date</returns>
        public static DateTime ReturnDayFromString(string date)
        {
            date = date.Trim();
            DateTime dayFromeString;

            bool isGoodDateFormat = DateTime.TryParseExact(
                              date,
                              "MM/dd/yyyy",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.None,
                               out dayFromeString);

            if (isGoodDateFormat == true)
            {
                return dayFromeString;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
        public enum MealType
        {
            Breakfast,
            SecondBreakfast 
        }
    }
}
