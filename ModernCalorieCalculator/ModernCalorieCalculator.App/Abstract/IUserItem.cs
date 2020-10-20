using ModernCalorieCalculator.Domain.Entity;
using System.Collections.Generic;

namespace ModernCalorieCalculator.App.Abstract
{
    public interface IUserUserItem
    {
        List<UserItem> UserItems { get; set; } 

        List<UserItem> GetAllUserItems();

        int AddUserItem(UserItem UserItem);

        int UpdateUserItem(UserItem UserItem);

        void RemoveUserItem(UserItem UserItem);

        UserItem GetUserUserItemById(int id);

        int GetLastId();


        // void AddUserUserItemToXml(UserItem userItem);
    }
}
