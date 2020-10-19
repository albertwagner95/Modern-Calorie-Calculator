using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Managers.Helpers;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.App.Concrete
{
    public class DayService : IDay
    {
        public List<Day> Days { get; set; }
        private IUser _userSerice;
        private IService _itemService;
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data\days.xml");
        public DayService(IUser userService, IService itemService)
        {
            _itemService = itemService;
            _userSerice = userService;
            var days = LoadDaysFromXml(path);
            Days = LoadDaysFromXml(path);

            if (Days == null)
            {
                Days = new List<Day>();
            }
        }
        public void AddDayToXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Days";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Day>), root);
            using StreamWriter sw = new StreamWriter(path);

            xmlSerializer.Serialize(sw, Days);
        }
        public int AddDay(Day day)
        {
            Days.Add(day);
            AddDayToXml();
            return (day.Id);
        }

        public int AddProductToUserDay(int productId, DateTime dayDate, int userId, string typeOfMeal, decimal grams)
        {
            var item = _itemService.GetItemById(productId);


            var day = Days.FirstOrDefault(x => x.UserDay == dayDate && x.UserId == userId);
            if (item != null && day != null)
            { 
                var itemToAddUserDay = DayManagerHelpers.ReturnConvertedValue(grams, item);
                itemToAddUserDay.TypeOfMeal = typeOfMeal;
                day.DayItems.Add(itemToAddUserDay);

                AddDayToXml();
                return item.Id;
            }
            else
            {
                return 0; //if zero -> product not found
            }
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

        private List<Day> LoadDaysFromXml(string path)
        {
            List<Day> days = new List<Day>();
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Days";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Day>), root);

            if (!File.Exists(path))
            {
                return null;
            }
            else
            {
                string xml = File.ReadAllText(path);
                using StringReader sr = new StringReader(xml);
                days = (List<Day>)xmlSerializer.Deserialize(sr);
                return days;
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

        public int GetLastId()
        {
            int lastId;

            if (Days.Any())
            {
                lastId = Days.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }
    }
}
