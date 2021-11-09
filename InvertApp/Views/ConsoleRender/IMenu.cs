using System.Collections.Generic;

namespace InvertApp.Views.ConsoleRender
{
    public interface IMenu
    {
        public MenuBuilder Builder { get; }
        public MenuElement GetElementById(string id);
        public IEnumerable<MenuElement> GetAllElementsById(string id);
        void Show();
    }
}