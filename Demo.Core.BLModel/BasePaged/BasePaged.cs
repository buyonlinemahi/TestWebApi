using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Core.BLModel.BasePaged
{
    public class BasePaged
    {
        [Key]
        public int TotalCount { get; set; }
    }
}
