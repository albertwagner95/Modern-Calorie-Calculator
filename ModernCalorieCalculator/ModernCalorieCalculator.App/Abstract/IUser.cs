using ModernCalorieCalculator.Domain.Entity;
using System.Collections.Generic;

namespace ModernCalorieCalculator.App.Abstract
{
    public interface IUser
    {
        List<User> Users { get; set; }

        List<User> GetUsers();

        int AddUser(User user);

        User GetUserById(int id);

        User FindUserByLogin(string userLogin);

        int GetLastId();
        void AddUserToXml(User newUser);
    }
}

