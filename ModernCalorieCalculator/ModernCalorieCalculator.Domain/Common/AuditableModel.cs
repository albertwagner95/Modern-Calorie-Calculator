using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.Domain.Common

{
    public class AuditableModel
    {
        public DateTime UpdateTime { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
