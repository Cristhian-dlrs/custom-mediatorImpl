using System;
using System.Collections.Generic;

namespace InvertApp.Views.ConsoleRender
{
    public sealed class Menu : IMenu
    {
        public MenuBuilder Builder { get; } = new ();
        
        private Stack<MenuElement> _menuStates = new ();

        public Menu()
        {
            _menuStates.Push(Builder.Root);
        }
        
        public void Show()
        {
            while (true)
            {
                var currentElement = _menuStates.Peek();
                if (_menuStates.Count == 1 || currentElement.ChildsCount > 0)
                    currentElement.Display();
                
                var isValid = int.TryParse(Console.ReadLine(), out var option);

                if (option > currentElement.ChildsCount || !isValid) 
                    continue;
                
                if (option == currentElement.ChildsCount && _menuStates.Count == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Exiting the application...");
                    break;
                }
                if (option == currentElement.ChildsCount)
                {
                    _menuStates.Pop();
                }
                else if (currentElement.SelectIndex(option).ChildsCount > 0)
                {
                    _menuStates.Push(currentElement.SelectIndex(option));
                }
            }
        }
        
        public MenuElement GetElementById(string id)
        {
           return Builder.Root.GetElementById(id);
        }

        public IEnumerable<MenuElement> GetAllElementsById(string id)
        {
            return Builder.Root.GetAllElementsById(id);
        }
    }
}