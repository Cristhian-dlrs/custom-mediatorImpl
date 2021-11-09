using InvertApp.Interfaces;
using InvertApp.Views.ConsoleRender;

namespace InvertApp.Views
{
    public class AppView
    {
        private readonly ICategoryController _categoryController;
        private readonly IProductController _productController;
        private readonly IStockController _stockController;
        private IMenu _menu = new Menu();

        public AppView(ICategoryController categoryController, IProductController productController, 
            IStockController stockController)
        {
            _categoryController = categoryController;
            _productController = productController;
            _stockController = stockController;
        }

        public void Run()
        {
            ConfigureMenu();
            _menu.Show();
        }

        private void ConfigureMenu()
        {
            _menu.Builder
                .NEW_MENU
                    .HEADER("InvertApp Main Menu")
                    .ADD_SUBMENU
                        .HEADER("mantenimiento de categorias", "categories")
                        .NewOption("agregar categoria.", _categoryController.Add)
                        .NewOption("editar categoria.", _categoryController.Update)
                        .NewOption("eliminar categoria.", _categoryController.Delete)
                        .NewOption("listar categorias.", _categoryController.GetAll)
                    .END_SUBMENU
                    .ADD_SUBMENU
                        .HEADER("mantenimiento de productos", "products")
                        .NewOption("agregar producto.", _productController.Add)
                        .NewOption("editar producto.", _productController.Update)
                        .NewOption("eliminar producto.", _productController.Delete)
                        .NewOption("listar productos.", _productController.GetAll)
                    .END_SUBMENU
                    .ADD_SUBMENU
                        .HEADER("manteminiemto inventario")
                        .NewOption("entrada de ivnentario", _stockController.AddStock)
                        .NewOption("salida deinventario", _stockController.ReduceStock)
                    .END_SUBMENU
                .Build();
        }
    }
}