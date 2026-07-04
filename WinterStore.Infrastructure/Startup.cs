using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Application.Common.Interfaces;
using WinterStore.Infrastructure.Data;
using WinterStore.Infrastructure.Persistence.Repositories;

namespace WinterStore.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<WinterDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            service.AddScoped<IProductRepository, ProductRepository>();

            return service;
        }
    }
}
