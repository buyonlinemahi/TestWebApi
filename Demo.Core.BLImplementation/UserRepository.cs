using Demo.Core.BL;
using Demo.Core.Data.Model;
using Demo.Core.Data.SQLServer;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Demo.Core.BLImplementation
{
    public class UserRepository : IUserRepository
    {
        private readonly BaseRepository<User> _userRepository;
        private readonly DemoDbContext _dbContext;
        public UserRepository(DemoDbContext DbContext)
        {
            _userRepository = new BaseRepository<User>(DbContext);
            _dbContext = DbContext;
        }
        #region Users
        public int AddUser(User _users)
        {
            return _userRepository.Add(_users).UserId;
        }

        public int UpdateUser(User _users)
        {
            return _userRepository.Update(_users);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public User GetUserByID(int _id)
        {
            return _userRepository.GetById(_id);
        }

        public User GetUserByEmailID(string Email)
        {
            var _User = _userRepository.GetAll().Where(user => user.EmailId == Email).FirstOrDefault();
            return _User ?? null;
        }

        public void updatePasswordByID(int UserID, string Password)
        {
            _dbContext.Database.ExecuteSqlCommand("Update_PasswordByID {0},{1}", UserID, Password);
        }

        public List<User> GetUsersByUserName(string UserName)
        {
            List<User> _User = _userRepository.GetAll().Where(user => user.UserName == UserName).ToList();
            return _User ?? null;
        }
        #endregion

    }
}
