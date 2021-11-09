using System;
using System.Reflection;
using InvertApp.Controllers;
using InvertApp.Data;
using InvertApp.Extensions;
using InvertApp.Interfaces;
using InvertApp.Repositories;
using InvertApp.Servcices;
using InvertApp.Servcices.RequestHandlers.Categories;
using InvertApp.Servcices.RequestHandlers.Products;
using InvertApp.Views;
using InvertApp.Views.ConsoleRender;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvertApp
{
    public static class Startup
    {
        public static IConfiguration Configuration { get; } = GetConfiguration();

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }

        public static IServiceProvider ConfigureAppServices(this IServiceCollection services)
        {
            services.AddDbContext<InvertAppContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("InvertApp"));
            });

            // Register Abstractions
            services
                .AddSingleton<AppView, AppView>()
                .AddSingleton<IMenu, Menu>()
                .AddScoped<ICategoryController, CategoryController>()
                .AddScoped<IProductController, ProductController>()
                .AddScoped<IStockController, StockController>()
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            // Mediator
            services.AddMediator(ServiceLifetime.Scoped, typeof(Program));

            return services.BuildServiceProvider();
        }
    }
}