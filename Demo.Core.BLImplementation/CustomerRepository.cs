using Demo.Core.BL;
using Demo.Core.Data.Model;
using Demo.Core.Data.SQLServer;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Omu.ValueInjecter;
using System.Linq;

namespace Demo.Core.BLImplementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaseRepository<Customer> _customerRepository;
        private readonly DemoDbContext _dbContext;
        public CustomerRepository(DemoDbContext DbContext)
        {
            _customerRepository = new BaseRepository<Customer>(DbContext);
            _dbContext = DbContext;
        }
        #region Customer
        public int AddCustomer(Customer _customer)
        {
            return _customerRepository.Add(_customer).CustomerID;
        }

        public int UpdateCustomer(Customer _customer)
        {
            return _customerRepository.Update(_customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
        }

        public Customer GetCustomerByID(int _id)
        {
            return _customerRepository.GetById(_id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetAll().Select(mahi => new Customer().InjectFrom(mahi)).Cast<Customer>().OrderBy(mahi => mahi.CustomerID).ToList();
        }

        public IEnumerable<Customer> GetCustomerByName(string CustomerName)
        {
            var s = _dbContext.Customers.FromSql($"GET_CustomersByName {CustomerName}");
            return s.ToList();
        }
        #endregion

    }
}