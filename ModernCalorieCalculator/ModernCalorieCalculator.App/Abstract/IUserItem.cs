using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.App.Abstract
{
    public interface IUserUserItem
    {
        List<UserItem> UserItems { get; set; }

        //UserItemConfiguration UserItemConfiguration { get; set; }

        List<UserItem> GetAllUserItems();

        int AddUserItem(UserItem UserItem);

        int UpdateUserItem(UserItem UserItem);

        void RemoveUserItem(UserItem UserItem);

        UserItem GetUserUserItemById(int id);

        int GetLastId();


       // void AddUserUserItemToXml(UserItem userItem);
    }
}
