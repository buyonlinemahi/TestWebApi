using System;
using System.Collections.Generic;
using System.Text;
using Demo.Core.BLModel.Base;

namespace Demo.Core.BLModel.Paged
{
    public class Order : BasePaged
    {
        public IEnumerable<Demo.Core.BLModel.Order> OrderDetails { get; set; }
    }
}
