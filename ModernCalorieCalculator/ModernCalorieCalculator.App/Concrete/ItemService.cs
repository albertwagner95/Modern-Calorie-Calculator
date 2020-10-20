using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.Domain;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.App.Concrete
{
    public class ItemService : IService
    {
        public List<Item> Items { get; set; }
        public ItemConfiguration ItemConfiguration { get; set; }
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data\products.xml");

        public ItemService()
        {

            Items = LoadItemsFromXml(path);
            if (Items == null)
            {
                Items = new List<Item>();
            }

            ItemConfiguration = new ItemConfiguration();
        }

        private List<Item> LoadItemsFromXml(string path)
        {
            List<Item> items = new List<Item>();
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Items";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Item>), root);

            if (!File.Exists(path))
            {
                return null;
            }
            else
            {
                string xml = File.ReadAllText(path);
                using StringReader sr = new StringReader(xml);
                items = (List<Item>)xmlSerializer.Deserialize(sr);
                return items;
            }
        }

        public void AddItemToXml(Item newItem)
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Items";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Item>), root);
            using StreamWriter sw = new StreamWriter(path);

            xmlSerializer.Serialize(sw, Items);
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
            var id = UpdateElementItem("Name", name, item);
            return id;
        }

        public int UpdateKcalPerOneHoundredGrams(int quantity, Item item)
        {
            var id = UpdateElementItem("KcalPerOneHounderGrams", quantity, item);
            return id;
        }

        public int UpdateProteinsPerOneHoundredGrams(int quantity, Item item)
        {
            var id = UpdateElementItem("QuantityProteinsPOHG", quantity, item);
            return id;
        }

        public int UpdateCarbohydratesPerOneHoundredGrams(int quantity, Item item)
        {
            var id = UpdateElementItem("QuantityCarbohydratesPOHG", quantity, item);
            return id;
        }

        public int UpdateFatsPerOneHoundredGrams(int quantity, Item item)
        {
            var id = UpdateElementItem("QuantityFatsPOHG", quantity, item);
            return id;
        }

        public int UpdateElementItem<T>(string attributeToUpdateName, T value, Item item)
        {
            XDocument doc = XDocument.Load(path);
            XElement node = doc.Descendants("Item").FirstOrDefault(x => x.Attribute("Id").Value == item.Id.ToString());
            node.SetElementValue(attributeToUpdateName, value);
            node.SetElementValue("UpdateTime", DateTime.UtcNow);
            doc.Save(path);
            Items = LoadItemsFromXml(path);
            var updateItem = GetItemById(item.Id);
            return updateItem.Id;
        }

    }
}
