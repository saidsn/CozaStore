using End_Project.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace End_Project.ViewModels.Product
{
    public class ProductEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
