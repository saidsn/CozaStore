using End_Project.Models;
using System.Collections.Generic;

namespace End_Project.ViewModels
{
    public class ProductDetailVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Models.Product> Products { get; set; }
        public IEnumerable<Header> Headers { get; set; }
        public Models.Product Product { get; set; }
        public Dictionary<string, string> Settings { get; set; }
        public Comment Comment { get; set; }
        public IEnumerable<Comment> ProductComments { get; set; }
    }
}
