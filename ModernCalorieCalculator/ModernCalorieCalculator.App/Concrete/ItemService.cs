using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.Domain;
using ModernCalorieCalculator.Domain.Common;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernCalorieCalculator.App.Concrete
{
    public class ItemService : IService
    {
        public List<Item> Items { get; set; }
        public ItemConfiguration ItemConfiguration { get; set; }

        public ItemService()
        {
            ItemConfiguration = new ItemConfiguration();
            Items = new List<Item>();
        }

        public int AddItem(Item item)
        {
            Items.Add(item);

            return item.Id;
        }

        public List<Item> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public int UpdateItem(Item item)
        {
            var entity = Items.FirstOrDefault(x => x.Id == item.Id);
            entity = item;
            return entity.Id;

        }

        public Item GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public int GetLastId()
        {
            int lastId;

            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public int UpdateName(string name, Item item)
        {
            var entity = Items.FirstOrDefault(x => x.Id == item.Id);
            entity.Name = name;
            entity.CreationDate = DateTime.Now;
            return entity.Id;
        }

        public int UpdateKcalPerOneHoundredGrams(int quantity, Item item)
        {
            var entity = Items.FirstOrDefault(x => x.Id == item.Id);
            entity.KcalPerOneHounderGrams = quantity;
            entity.CreationDate = DateTime.Now;
            return entity.Id;
        }

        public int UpdateProteinsPerOneHoundredGrams(int quantity, Item item)
        {
            var entity = Items.FirstOrDefault(x => x.Id == item.Id);
            entity.QuantityProteinsPOHG = quantity;
            entity.CreationDate = DateTime.Now;
            return entity.Id;
        }

        public int UpdateCarbohydratesPerOneHoundredGrams(int quantity, Item item)
        {
            var entity = Items.FirstOrDefault(x => x.Id == item.Id);
            entity.QuantityCarbohydratesPOHG = quantity;
            entity.CreationDate = DateTime.Now;
            return entity.Id;
        }

        public int UpdateFatsPerOneHoundredGrams(int quantity, Item item)
        {
            var entity = Items.FirstOrDefault(x => x.Id == item.Id);
            entity.QuantityFatsPOHG = quantity;
            entity.CreationDate = DateTime.Now;
            return entity.Id;
        }
    }
}
