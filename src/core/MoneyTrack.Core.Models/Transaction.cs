﻿using System;

namespace MoneyTrack.Core.Models
{
    public class Transaction
    {
        public static DateTimeOffset CutOffDate = new DateTimeOffset(1970, 1, 1, 1, 1, 1, TimeSpan.Zero);

        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public DateTimeOffset AddedDttm { get; set; }
        public bool IsPostponed { get; set; }
    }
}
