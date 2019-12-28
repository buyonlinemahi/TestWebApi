using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Core.Data.Model
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string Name { get; set; }

    }
}
