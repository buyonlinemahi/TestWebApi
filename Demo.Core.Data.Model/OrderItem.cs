using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Core.Data.Model
{
    public class OrderItem
    {
        [Key]
        public long OrderItemID { get; set; }
        [ForeignKey("OrderID")]
        public long OrderID { get; set; }
        [ForeignKey("ItemID")]
        public int ItemID { get; set; }
        public int Quantity { get; set; }

    }
}
