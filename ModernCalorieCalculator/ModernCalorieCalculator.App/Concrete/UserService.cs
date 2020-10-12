using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.App.Concrete
{
    public class UserService : IUser
    {
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data\users.xml");
        public List<User> Users { get; set; }

        public UserService()
        {
            Users = LoadUsersFromXml(path);

            if (Users == null)
            {
                Users = new List<User>();
            }
        }
        public int AddUser(User user)
        {
            Users.Add(user);
            AddUserToXml(user);
            return user.Id;
        }

        public User GetUserById(int id)
        {
            if (id > 0)
            {
                var user = Users.FirstOrDefault(x => x.Id == id);
                return user;
            }
            else return null;
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public User FindUserByLogin(string userLogin)
        {
            var user = Users.FirstOrDefault(x => x.Login == userLogin);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public int GetLastId()
        {
            int lastId;

            if (Users.Any())
            {
                lastId = Users.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public void AddUserToXml(User newUser)
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Users";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>), root);
            using StreamWriter sw = new StreamWriter(path);

            xmlSerializer.Serialize(sw, Users);
        }

        private List<User> LoadUsersFromXml(string path)
        {
            List<User> users = new List<User>();
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Users";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>), root);

            if (!File.Exists(path))
            {
                return null;
            }
            else
            {
                string xml = File.ReadAllText(path);
                using StringReader sr = new StringReader(xml);
                users = (List<User>)xmlSerializer.Deserialize(sr);
                return users;
            }
        }
    }
}
