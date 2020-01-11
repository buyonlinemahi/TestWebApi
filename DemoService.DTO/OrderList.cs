using System;
using System.Collections.Generic;
using System.Text;

namespace DemoService.DTO
{
    public class OrderList
    {
        public IEnumerable<Order> OrderLists { get; set; }
        public int TotalCount { get; set; }
    }
}
