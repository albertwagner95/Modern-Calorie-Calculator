using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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

