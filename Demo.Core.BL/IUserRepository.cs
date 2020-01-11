using System;
using System.Collections.Generic;
using System.Text;
using Demo.Core.Data.Model;

namespace Demo.Core.BL
{
    public interface IUserRepository
    {
        #region User 
        int AddUser(User _users);
        int UpdateUser(User _users);
        void DeleteUser(int id);
        User GetUserByID(int _id);
        User GetUserByEmailID(string Email);
        void updatePasswordByID(int UserID, string Password);
        User GetUsersDetailsByLogin(string UserName, string Password);
        List<User> GetUsersByUserName(string UserName);
        #endregion

    }
}
