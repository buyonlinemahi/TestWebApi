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
    public class CustomerTest
    {
        ICustomerRepository _customerRepository;
        readonly DemoDbContext _context;
        public CustomerTest()
        {
            var builder = new DbConnection();
            _context = new DemoDbContext((builder.InitConfiguration()).Options);
            _customerRepository = new CustomerRepository(_context);
        }

        #region Customers

        [Fact]
        public void Get_Customer()
        {
            var customerName = _customerRepository.GetCustomerByName("o");
            Assert.True(customerName != null, "failed");
        }

        #endregion
    }
}
