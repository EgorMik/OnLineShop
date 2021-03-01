﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OnLineShop.Core.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Payment Received")]
        PaymentReceived,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed

    }
}
