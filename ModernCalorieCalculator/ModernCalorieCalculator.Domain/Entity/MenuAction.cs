using ModernCalorieCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.Domain.Entity
{
    public class MenuAction : AuditableModel
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string MenuName { get; set; }

        public MenuAction(int id, string name, string menuName)
        {
            Id = id;
            Name = name;
            MenuName = menuName;
        }
    }
}
