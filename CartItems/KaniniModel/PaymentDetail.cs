﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CartItems.KaniniModel
{
    public partial class PaymentDetail
    {
        public string CardHolderName { get; set; }
        public float? DebitCardNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int CvvPin { get; set; }
    }
}