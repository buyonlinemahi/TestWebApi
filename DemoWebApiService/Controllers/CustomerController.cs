using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Demo.Core.BL;
using Demo.Core.BLImplementation;
using Demo.Core.Data.SQLServer;
using DemoService.DTO;
using System.Collections.Generic;
using DemoWebApiService.Services;
using System;

namespace DemoWebApiService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(DemoDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = new CustomerRepository(context);
        }
        [HttpGet("api/Customer/GetCustomers")]
        public IActionResult GetCustomers()
        {
            try
            {
                IEnumerable<Customer> _customer = _mapper.Map<IEnumerable<Customer>>(_customerRepository.GetCustomers());
                return _customer == null ? NotFound(_customer) : (IActionResult)Ok(_customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("api/Customer/GetCustomerByName/{CustomerName}")]
        public IActionResult GetCustomerByName(string CustomerName)
        {
            try
            {
                IEnumerable<Customer> _customer = _mapper.Map<IEnumerable<Customer>>(_customerRepository.GetCustomerByName(CustomerName));
                return _customer == null ? NotFound(_customer) : (IActionResult)Ok(_customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}