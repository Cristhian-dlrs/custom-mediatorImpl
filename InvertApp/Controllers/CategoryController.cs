using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvertApp.Data;
using InvertApp.Interfaces;
using InvertApp.Servcices.Requests.Categories;

namespace InvertApp.Controllers
{
    public class CategoryController : ICategoryController
    {
        private readonly IMediator _appService;

        public CategoryController(IMediator appService)
        {
            _appService = appService;
        }

        public void Add()
        {
            Console.Write("Category name: ");
            var name = Console.ReadLine();
            var category = new Category() { Name = name };
            var response = _appService.Send(new CreateCategoryRequest(category));
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

        public void Update()
        {
            GetAllList();
            Console.Write("Category id: ");
            var isValidId =  int.TryParse(Console.ReadLine(), out var id);

            if (!isValidId)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid input type for Id.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                return;
            }
            
            Console.Write("Category name: ");
            var name = Console.ReadLine();
            var category = new Category() { Name = name, Id = id};
            var response = _appService.Send(new UpdateCategoryRequest(category));
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
            GetAllList();
            Console.Write("Category id: ");
            var isValidId =  int.TryParse(Console.ReadLine(), out var id);

            if (!isValidId)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid input type for Id.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                return;
            }
            
            var response = _appService.Send(new DeleteCategoryRequest(id));
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

        public void GetAllList()
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
    }
}