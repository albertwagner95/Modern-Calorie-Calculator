using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.Domain.Entity
{
    public class Day
    {
        public int Id { get; set; }
        public DateTime UserDay{ get; set; } 
        public int UserId { get; set; }
        public decimal SumKcal { get; set; }
        public decimal SumCarbohydrates { get; set; }
        public decimal SumProteins { get; set; }
        public decimal SumFats { get; set; }
        public string TypeOfMeal { get; set; }

    }
}
