using System;
using System.Collections.Generic;

#nullable disable

namespace InvertApp.Data
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Strock { get; set; }

        public virtual Category Category { get; set; }
        
        public string ToInventory()
        {
            return "\n{" +
                   $"\n\t\"Id\": {Id}," +
                   $"\n\t\"Name\": {Name}," +
                   $"\n\t\"Stock\": {Strock}," +
                   "\n}";
        }

        public override string ToString()
        {
            return "\n{" +
                   $"\n\t\"Id\": {Id}," +
                   $"\n\t\"Name\": {Name}," +
                   $"\n\t\"Price\": {Price}," +
                   $"\n\t\"Category\": {Category?.Name}," +
                   $"\n\t\"Stock\": {Strock}," +
                   "\n}";
        }
    }
}
