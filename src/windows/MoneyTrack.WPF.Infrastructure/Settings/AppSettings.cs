﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTrack.WPF.Infrastructure.Settings
{
    public class AppSettings
    {
        public int NumberOfLastTransaction { get; set; }
        public string LiteDBConnection { get; set; }
    }
}