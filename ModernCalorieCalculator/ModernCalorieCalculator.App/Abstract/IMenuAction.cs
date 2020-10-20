using ModernCalorieCalculator.Domain.Entity;
using System.Collections.Generic;

namespace ModernCalorieCalculator.App.Abstract
{
    interface IMenuAction
    {
        List<MenuAction> Items { get; set; }

        List<MenuAction> GetAllItems();

        int AddItem(MenuAction item);

        int UpdateItem(MenuAction item);

        void RemoveItem(MenuAction item);

        MenuAction GetItemById(int id);

    }
}
