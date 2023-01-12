using End_Project.Models;
using System.Collections.Generic;

namespace End_Project.ViewModels.Product
{
    public class ProductListVM
    {
        public int Id { get; set; }
        public string MainImage { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
       
    }
}
