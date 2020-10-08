using ModernCalorieCalculator.Domain;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.App.Abstract
{
    public interface IService
    {
        List<Item> Items { get; set; }

        ItemConfiguration ItemConfiguration { get; set; }

        List<Item> GetAllItems();

        int AddItem(Item item);

        int UpdateItem(Item item);

        void RemoveItem(Item item);

        Item GetItemById(int id);

        int GetLastId();

        int UpdateName(string name, Item item);

        int UpdateKcalPerOneHoundredGrams(int quantity, Item item);

        int UpdateProteinsPerOneHoundredGrams(int quantity, Item item);

        int UpdateCarbohydratesPerOneHoundredGrams(int quantity, Item item);

        int UpdateFatsPerOneHoundredGrams(int quantity, Item item);
    }
}
