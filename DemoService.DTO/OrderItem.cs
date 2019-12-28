﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DemoService.DTO
{
    public class OrderItem
    {
        public long OrderItemID { get; set; }
        public long OrderID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public decimal Total { get; set; }
    }
}