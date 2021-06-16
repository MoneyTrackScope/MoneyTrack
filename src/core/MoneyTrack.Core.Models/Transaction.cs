﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTrack.Core.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Account { get; set; }
        public DateTimeOffset AddedDttm { get; set; }
    }
}