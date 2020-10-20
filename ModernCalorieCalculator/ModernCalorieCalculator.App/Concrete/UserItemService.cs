using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.App.Concrete
{
    public class UserItemService
    {
        public List<UserItem> UserItems { get; set; }
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data\user_items.xml");

        public UserItemService()
        {

            UserItems = LoadUserItemsFromXml(path);
            if (UserItems == null)
            {
                UserItems = new List<UserItem>();
            }

        }

        private List<UserItem> LoadUserItemsFromXml(string path)
        {
            List<UserItem> UserItems = new List<UserItem>();
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "UserItems";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UserItem>), root);

            if (!File.Exists(path))
            {
                return null;
            }
            else
            {
                string xml = File.ReadAllText(path);
                using StringReader sr = new StringReader(xml);
                UserItems = (List<UserItem>)xmlSerializer.Deserialize(sr);
                return UserItems;
            }
        }

        public void AddUserItemToXml(UserItem newUserItem)
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "UserItems";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UserItem>), root);
            using StreamWriter sw = new StreamWriter(path);

            xmlSerializer.Serialize(sw, UserItems);
        }
        public int AddUserItem(UserItem UserItem)
        {
            UserItems.Add(UserItem);

            return UserItem.Id;
        }

        public List<UserItem> GetAllUserItems()
        {
            return UserItems;
        }

        public void RemoveUserItem(UserItem UserItem)
        {
            UserItems.Remove(UserItem);
        }

        public int UpdateUserItem(UserItem UserItem)
        {
            var entity = UserItems.FirstOrDefault(x => x.Id == UserItem.Id);
            entity = UserItem;
            return entity.Id;
        }

        public UserItem GetUserItemById(int id)
        {
            var entity = UserItems.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public int GetLastId()
        {
            int lastId;

            if (UserItems.Any())
            {
                lastId = UserItems.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }
    }
}
