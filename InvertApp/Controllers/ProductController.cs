using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Categories;
using InvertApp.Servcices.Requests.Products;

namespace InvertApp.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IMediator _appService;

        public ProductController(IMediator appService)
        {
            _appService = appService;
        }

        public void Add()
        {
            if (!isAviable())
            {
                Console.WriteLine("Create a category first.");
                return;
            }
            Console.Write("Product name: ");
            var name = Console.ReadLine();
            Console.Write("Product price: ");
            var isPriceValid =  int.TryParse(Console.ReadLine(), out var price);

            if (!isPriceValid)
            {
                InvalidInput("price");
                return;
            }
            
            Console.Write("Initial stock: ");
            var isPvalidStock =  int.TryParse(Console.ReadLine(), out var stock);

            if (!isPvalidStock)
            {
                InvalidInput("stock");
                return;
            }
            
            GetAllCaategries();
            Console.Write("Product category(id): ");
            var isCategory =  int.TryParse(Console.ReadLine(), out var categoryId);

            if (!isCategory)
            {
                InvalidInput("stock");
                return;
            }
            if (!IsExistentCategory(categoryId))
            {
                InvalidInput("Category, Id does not exists.");
                return;
            }

            var product = new Product()
                { Name = name, CategoryId = categoryId, Price = price, Strock = stock };

            var response = _appService.Send(new CreateProductRequest(product));
            if (response.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
            }
        }

        public void Update()
        {
            if (!isAviable())
            {
                Console.WriteLine("No products aviables.");
                return;
            }
                
            GetAllList();
            Console.Write("Product id: ");
            var isValidId =  int.TryParse(Console.ReadLine(), out var id);

            if (!isValidId)
            {
                InvalidInput("id");
                return;
            }
            Console.Write("Product name: ");
            var name = Console.ReadLine();
            Console.Write("Product price: ");
            var isPriceValid =  int.TryParse(Console.ReadLine(), out var price);

            if (!isPriceValid)
            {
                InvalidInput("price");
                return;
            }
            
            Console.Write("Product stock: ");
            var isPvalidStock =  int.TryParse(Console.ReadLine(), out var stock);

            if (!isPvalidStock)
            {
                InvalidInput("stock");
                return;
            }
            
            GetAllCaategries();
            Console.Write("Product category(id): ");
            var isCategory =  int.TryParse(Console.ReadLine(), out var categoryId);

            if (!isCategory)
            {
                InvalidInput("stock");
                return;
            }
            if (!IsExistentCategory(categoryId))
            {
                InvalidInput("Category, Id does not exists.");
                return;
            }

            var product = new Product()
                { Id = id, Name = name, CategoryId = categoryId, Price = price, Strock = stock };

            var response = _appService.Send(new UpdateProductRequest(product));
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

        public void Delete()
        {
            if (!isAviable())
            {
                Console.WriteLine("No products aviables.");
                return;
            }
            GetAllList();
            Console.Write("Product id: ");
            var isValidId =  int.TryParse(Console.ReadLine(), out var id);

            if (!isValidId)
            {
                InvalidInput("id");
                return;
            }
            
            var response = _appService.Send(new DeleteProdcutRequest(id));
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

        public void GetAll()
        {
            GetAllList();
            Console.ReadKey();
        }
        
        private void GetAllList()
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
            }
        }

        private void GetAllCaategries()
        {
            var response = _appService.Send(new GetAllCategoriesRequest());
            if (response.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Parallel.ForEach(response.Data, (category) =>
                {
                    Console.WriteLine($"{category},\n");
                });
         
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public bool IsExistentCategory(int id)
        {
            var response = _appService.Send(new GetCategoryRequest(x => x.Id == id));
            return response.Success;
        }

        private void InvalidInput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid input type for {message}.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
        }

        private bool isAviable()
        {
            return _appService.Send(new GetAllCategoriesRequest()).Data.Any();
        }
    }
}