using ModernCalorieCalculator.Domain.Common;

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
