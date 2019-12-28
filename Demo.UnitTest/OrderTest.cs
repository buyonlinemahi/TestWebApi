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
    public class OrderTest
    {
        IOrderRepository _OrderRepository;
        readonly DemoDbContext _context;
        public OrderTest()
        {
            var builder = new DbConnection();
            _context = new DemoDbContext((builder.InitConfiguration()).Options);
            _OrderRepository = new OrderRepository(_context);
        }

        #region Users
      
        [Fact]
        public void Get_Orders()
        {
            var userByName = _OrderRepository.GetOrders();
            Assert.True(userByName != null, "failed");
        }
       
        #endregion
    }
}
