using ModernCalorieCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.Domain.Entity
{
    public class Category : AuditableModel
    { 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            
        }
    }
}
