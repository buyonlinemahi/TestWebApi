using Demo.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BL
{
    public interface ICustomerRepository
    {
        #region Customer
        int AddCustomer(Customer _customer);
        int UpdateCustomer(Customer _customer);
        void DeleteCustomer(int id);
        Customer GetCustomerByID(int _id);
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Customer> GetCustomerByName(string Name);
        #endregion
    }
}
