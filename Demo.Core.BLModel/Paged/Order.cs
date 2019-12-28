using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BLModel.Paged
{
    public class Order
    {
        public IEnumerable<Demo.Core.BLModel.Order> OrderDetails { get; set; }
    }
}
