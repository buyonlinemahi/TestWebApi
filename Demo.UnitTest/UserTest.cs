using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Demo.Core.BL;
using Demo.Core.BLImplementation;
using Demo.Core.Data.Model;
using Demo.Core.Data.SQLServer;
using System;
using Xunit;

namespace Demo.UnitTest
{
    public class UserTest
    {
        IUserRepository _userRepository;
        readonly DemoDbContext _context;

        public UserTest()
        {
            var builder = new DbConnection();
            _context = new DemoDbContext((builder.InitConfiguration()).Options);
            _userRepository = new UserRepository(_context);
        }

        #region Users
        [Fact]
        public void Adduser()
        {
            User _user = new User
            {
                UserName = "e",
                FirstName = "TestDheeraj",
                LastName = "TestLName",
                EmailId = "dsharma@test.com",
                Password = "abcsasd"

            };
            var id = _userRepository.AddUser(_user);
            Assert.True(id > 0, "failed");

        }

        [Fact]
        public void UpdateUser()
        {
            User _user = new User
            {
                UserId = 1,
                UserName = "Tikku",
                FirstName = "Sharma",
                LastName = "dSharma",
                EmailId = "dsharma@test.com",
                Password = "s"
               
            };
            var id = _userRepository.UpdateUser(_user);
            Assert.True(id > 0, "failed");
        }


        [Theory]
        [InlineData(4)]
        public void DeleteUser(int ID)
        {
            _userRepository.DeleteUser(ID);
        }

        [Theory]
        [InlineData(1)]
        public void GetUserByID(int ID)
        {
            var userByName = _userRepository.GetUserByID(ID);
            Assert.True(userByName != null, "failed");
        }

        [Fact]
        public void GetUserByEmailID()
        {
            var userByName = _userRepository.GetUserByEmailID("dsharma@test.com");
            Assert.True(userByName != null, "failed");
        }
        [Fact]
        public void updatePasswordByID()
        {
            _userRepository.updatePasswordByID(2, "test@123");

        }
        [Fact]
        public void Get_UsersDetailsByLogin()
        {
            var userByName = _userRepository.GetUsersDetailsByLogin("Tikku","1");
            Assert.True(userByName != null, "failed");
        }
        [Fact]
        public void Get_UsersByUserName()
        {
            var userByName = _userRepository.GetUsersByUserName("t");
            Assert.True(userByName != null, "failed");
        }

        #endregion
    }
}
