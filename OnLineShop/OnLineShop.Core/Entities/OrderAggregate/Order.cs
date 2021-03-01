using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineShop.Core.Entities.OrderAggregate
{
    public class Order: BaseEntity
    {
        public Order(string buyerEmail,
            Address shipToAddress,
            IReadOnlyList<OrderItem> orderItems,
            DeliveryMethod deliveryMethod,
            decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            OrderItems = orderItems;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
           
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }

    }
}
