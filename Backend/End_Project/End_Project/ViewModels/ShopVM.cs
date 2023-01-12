using End_Project.Models;
using System.Collections.Generic;

namespace End_Project.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Brend> Brends { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public IEnumerable<Models.Product> Products { get; set; }
        public IEnumerable<Header> Headers { get; set; }
        public Models.Product Product { get; set; }

    }
}
