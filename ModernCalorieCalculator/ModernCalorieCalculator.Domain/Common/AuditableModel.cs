using System;
using System.Xml;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.Domain.Common

{
    public class AuditableModel
    {
        [XmlElement("UpdateTime")]
        public DateTime UpdateTime { get; set; }
        [XmlElement("CreationDate")]
        public DateTime CreationDate { get; set; }

    }
}
