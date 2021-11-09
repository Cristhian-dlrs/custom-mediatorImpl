using InvertApp.Interfaces;
using InvertApp.Servcices;
using InvertApp.Views;
using Microsoft.Extensions.DependencyInjection;

namespace InvertApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ServiceProvider = new ServiceCollection().ConfigureAppServices();
            // var mediator = new InventoryService(ServiceProvider.GetRequiredService);
            var app = ServiceProvider.GetService<AppView>();
            app.Run();
        }
    }
}