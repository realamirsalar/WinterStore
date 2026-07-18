using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using WinterStore.Domain.Entities;

namespace WinterStore.Infrastructure.Configurations
{
    internal class ItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder
                .HasOne(bi => bi.Product)
                .WithMany()
                .HasForeignKey(bi => bi.ProductId);
        }
    }
}
