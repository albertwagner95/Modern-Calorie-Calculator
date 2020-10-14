using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ModernCalorieCalculator.App.Managers.Helpers
{
   public class DayManagerHelpers
    {
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

    }
}
