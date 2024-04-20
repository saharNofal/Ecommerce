using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services , IConfiguration configuration)
        {


            services.AddDbContext<EcommerceDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("EcommerceConnectionString")));


          
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<EcommerceDbContext>();
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
