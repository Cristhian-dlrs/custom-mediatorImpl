using System;
using System.Collections.Generic;

namespace InvertApp.Views.ConsoleRender
{
    public class MenuElement
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Styles Styles { get; set; } = new ();
        public int ChildsCount => _childs.Count;
        
        private Action _action;
        private int _index;
        private  List<MenuElement> _childs = new ();
        
        public MenuElement(string title = null, Action action = null, string id = null)
        {
            Title = title;
            _action = action;
            Id = id;
        }

        public void AppendChild(MenuElement element)
        {
            element._index = _childs.Count + 1;
            _childs.Add(element);
        }
        
        public MenuElement SelectIndex(int index)
        {
            var option = _childs[--index];
            option.Display();
            option._action?.Invoke();
            
            return option;
        }

        public void Display()
        {
            Console.Clear();
            Console.ForegroundColor = Styles.ColorHeader;
            Console.WriteLine($"//***********    {Title.ToUpper()}    ***********\\\\\r\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var element in _childs) element.Print();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n>> ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Print()
        {
            if (!Styles.Hidden)
            {
                Console.ForegroundColor = Styles.Color;
                Console.WriteLine($"[{ _index }]-{ CapitalizrFirst(Title) }\r\n");
                Console.ForegroundColor = ConsoleColor.White;
            }    
        }

        private string CapitalizrFirst(string str)
        {
            if (str.Length == 1)
                return char.ToUpper(str[0]).ToString();
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        public MenuElement GetElementById(string id)
        {
            if (Id == id)
                return this;

            foreach (var child in _childs)
            {
                var result = child.GetElementById(id);
                if (result != null) return result;
            }

            return null;
        }

        public IEnumerable<MenuElement> GetAllElementsById(string id)
        {
            var result = new List<MenuElement>();
            if (Id == id)
                result.Add(this);
            
            foreach (var child in _childs)
            {
                var elements = child.GetAllElementsById(id);
                if (elements != null) result.AddRange(elements);
            }
            
            return result;
        }

    }
}