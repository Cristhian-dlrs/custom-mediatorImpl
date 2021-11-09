using System;

namespace InvertApp.Views.ConsoleRender
{
    public class MenuBuilder
    {
        private MenuBuilder(MenuBuilder parent)
            : this ()
        {
            _parent = parent;
        }
        
        public MenuElement Root { get; }

        private readonly MenuBuilder _parent;

        public MenuBuilder() => Root = new MenuElement();


        public MenuBuilder NEW_MENU => this;

        public MenuBuilder ADD_SUBMENU => new (this);

        public MenuBuilder END_SUBMENU
        {
            get
            {
                NewOption("Atrás", () => { }, "atras");
                _parent.Root.AppendChild(Root);
                return _parent;
            }
        }

        public void Build()
        {
            NewOption("Salir", () => { }, "salir");
        }

        public MenuBuilder HEADER(string title, string id = null)
        {
            Root.Title = title;
            Root.Id = id;
            return this;
        }

        public MenuBuilder NewOption(string title, Action action, string id = null)
        {
            var option = new MenuElement(title, action, id);
            Root.AppendChild(option);
            return this;
        }

        public static implicit operator MenuElement(MenuBuilder builder)
        {
            return builder.Root;
        }          
    }
}