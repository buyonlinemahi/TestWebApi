﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DemoService.DTO
{
    public class PaymentDetail
    {
        public int PMId { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }
}
