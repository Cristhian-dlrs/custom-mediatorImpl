using System;
using System.Threading;
using System.Threading.Tasks;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Products;

namespace InvertApp.Controllers
{
    public class StockController : IStockController
    {
        private readonly IMediator _appService;

        public StockController(IMediator appService)
        {
            _appService = appService;
        }

        public void AddStock()
        {
            ListProducts();
            Console.Write("Product id: ");
            var isIdValid =  int.TryParse(Console.ReadLine(), out var id);

            if (!isIdValid)
            {
                InvalidInput("id");
                return;
            }
            
            Console.Write("Stock to add: ");
            var isIdStock =  int.TryParse(Console.ReadLine(), out var stock);

            if (!isIdStock)
            {
                InvalidInput("stock");
                return;
            }

            var prdocut = new Product() { Id = id, Strock = stock };
            var response = _appService.Send(new AddStockRequest(prdocut));
            if (response.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
            }
        }
        
        public void ReduceStock()
        {
            ListProducts();
            Console.Write("Product id: ");
            var isIdValid =  int.TryParse(Console.ReadLine(), out var id);

            if (!isIdValid)
            {
                InvalidInput("id");
                return;
            }
            
            Console.Write("Stock to reduce: ");
            var isIdStock =  int.TryParse(Console.ReadLine(), out var stock);

            if (!isIdStock)
            {
                InvalidInput("stock");
                return;
            }

            var prdocut = new Product() { Id = id, Strock = stock };
            var response = _appService.Send(new ReduceStockReqeust(prdocut));
            if (response.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
            }
        }

        private void ListProducts()
        {
            var response = _appService.Send(new GetAllProductsRequest());
            if (response.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Parallel.ForEach(response.Data, (product) =>
                {
                    Console.WriteLine($"{product},\n");
                });
         
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
            }
        }
        
        private void InvalidInput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid input type for {message}.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
        }
    }
}