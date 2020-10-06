using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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
