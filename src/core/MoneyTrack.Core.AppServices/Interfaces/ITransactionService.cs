﻿using MoneyTrack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTrack.Core.AppServices.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetLastTransaction(int numberOfLastTransaction);
    }
}