using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnLineShop.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineShop.Infrastructure.Data.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(i => i.ItemOrdered, io =>
            {
                io.WithOwner();

            });

            builder.Property(i => i.Price)
                .HasColumnType("decimal(18,2)");
                
        }
    }
}
