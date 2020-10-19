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
        [XmlArrayItem(Type = typeof(UserItem))]
        public List<UserItem> DayItems { get; set; }
        [XmlElement("UserId")]
        public int UserId { get; set; }
        [XmlElement("UserItems")]
        public List<UserItem> UserItems { get; set; }

        public Day()
        {

        }
        public Day(int id, DateTime userDay, int userId)
        {
            Id = id;
            UserDay = userDay;
            UserId = userId; 
        }
    }
}
