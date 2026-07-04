using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinterStore.Infrastructure.Data
{
    public class WinterDbContext : DbContext
    {
        public WinterDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
