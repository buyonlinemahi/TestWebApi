using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Core.Data.Model
{
    public class Order
    {
        [Key]
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        public string PMethod { get; set; }
        public decimal GTotal { get; set; }

    }
}
