using System;
using System.Collections.Generic;
using System.Text;

namespace DemoService.DTO
{
    public class Order
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public int CustomerID { get; set; }
        public string PMethod { get; set; }
        public decimal GTotal { get; set; }
        public string CustomerName { get; set; }
        public string DeletedOrderItemIDs { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
