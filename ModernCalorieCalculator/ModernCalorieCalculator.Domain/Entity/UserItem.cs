using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.Domain.Entity
{
    public class UserItem : Item
    {
        public string TypeOfMeal { get; set; }
        public DateTime DateAdd { get; set; }  
        public int UserId { get; set; }

        public UserItem() : base()
        {

        }
    }
}
