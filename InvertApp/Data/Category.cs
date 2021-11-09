using System;
using System.Collections.Generic;

#nullable disable

namespace InvertApp.Data
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return "\n{" +
                   $"\n\t\"Id\": {Id}," +
                   $"\n\t\"Name\": {Name}," +
                   "\n}";
        }
    }
}
