using ModernCalorieCalculator.Domain.Common;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.Domain.Entity
{
    public class Category : AuditableModel
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }
        [XmlElement("CategoryName")]
        public string CategoryName { get; set; }

        public Category()
        {

        }
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
    }
}
