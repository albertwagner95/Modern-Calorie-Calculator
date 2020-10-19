using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            SecondBreakfast,
            Lunch,
            Dinner,
            Supper,
            Snack
        }

        public static decimal ReturnCalorieSummary(List<UserItem> items)
        {
            if (!items.Any())
            {
                return 0;
            }
            else
            {
                return items.Sum(x => x.KcalPerOneHounderGrams);
            }
        }

        public static decimal ReturnFatSummary(List<UserItem> items)
        {
            if (!items.Any())
            {
                return 0;
            }
            else
            {
                return items.Sum(x => x.QuantityFatsPOHG);
            }
        }

        public static decimal ReturnCarbohydratesSummary(List<UserItem> items)
        {
            if (!items.Any())
            {
                return 0;
            }
            else
            {
                return items.Sum(x => x.QuantityCarbohydratesPOHG);
            }
        }

        public static decimal ReturnProteinsSummary(List<UserItem> items)
        {
            if (!items.Any())
            {
                return 0;
            }
            else
            {
                return items.Sum(x => x.QuantityProteinsPOHG);
            }
        }

        public static decimal ReturnCostSummary(List<UserItem> items)
        {
            if (!items.Any())
            {
                return 0;
            }
            else
            {
                return items.Sum(x => x.ProductCost);
            }
        }

        public static UserItem ReturnConvertedValue(decimal grams, Item item)
        {
            var percent = decimal.Divide(grams, 100);
            UserItem userItem = new UserItem();
            userItem.Id = item.Id;
            userItem.Name = item.Name;
            userItem.KcalPerOneHounderGrams = Math.Round(decimal.Multiply(percent, item.KcalPerOneHounderGrams));
            userItem.QuantityCarbohydratesPOHG = decimal.Multiply(percent, item.QuantityCarbohydratesPOHG);
            userItem.QuantityProteinsPOHG = decimal.Multiply(percent, item.QuantityProteinsPOHG);
            userItem.QuantityFatsPOHG = decimal.Multiply(percent, item.QuantityFatsPOHG);
            userItem.ProductCost = decimal.Multiply(percent, item.ProductCost);

            return userItem;
        }
    }
}
