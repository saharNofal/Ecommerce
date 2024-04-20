using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationservice(this IServiceCollection services)
        {
        //    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           return services;

        }
    }
}
