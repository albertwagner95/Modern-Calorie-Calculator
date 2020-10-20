using System;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.Domain.Entity
{
    public class User
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("Login")]
        public string Login { get; set; }
        [XmlElement("Age")]
        public int Age { get; set; }
        [XmlElement("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        public User()
        {

        }
        public User(int id, string name, string lastName, string login)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Login = login;
        }
    }
}
