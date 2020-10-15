using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.Domain.Entity
{
    public class Day
    { 
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlElement("UserDay")]
        public DateTime UserDay { get; set; }
        [XmlElement("SumKcal")]
        public decimal SumKcal { get; set; }
        [XmlElement("SumCarbohydrates")]
        public decimal SumCarbohydrates { get; set; }
        [XmlElement("SumProteins")]
        public decimal SumProteins { get; set; }
        [XmlElement("SumFats")]
        public decimal SumFats { get; set; }
        [XmlElement("TypeOfMeal")]
        public string TypeOfMeal { get; set; }
        [XmlArrayItem(Type = typeof(Item))]
        public List<Item> DayItems { get; set; }
        [XmlElement("UserId")]
        public int UserId { get; set; }

        public Day()
        {

        }
        public Day(int id, DateTime userDay, int userId, List<Item> items)
        {
            Id = id;
            UserDay = userDay;
            UserId = userId;
            DayItems = items;
        }
    }
}
