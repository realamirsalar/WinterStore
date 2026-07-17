using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Domain.Entities;

namespace WinterStore.Infrastructure.Configurations
{
    internal class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasMany(x => x.Items).WithOne(x => x.Basket).HasForeignKey(x => x.BasketId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
