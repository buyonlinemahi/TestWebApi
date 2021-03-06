﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BLModel
{
    public class OrderItem
    {
        public long OrderItemID { get; set; }
        public long OrderID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; } 
    }
}
