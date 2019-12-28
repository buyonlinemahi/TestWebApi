using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Core.Data.Model
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
