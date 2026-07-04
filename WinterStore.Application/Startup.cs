using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WinterStore.Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddAutoMapper(cfg => { } , Assembly.GetExecutingAssembly());

            return service;
        }
    }
}
