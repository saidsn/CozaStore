using End_Project.Models;
using System.Collections.Generic;

namespace End_Project.ViewModels.Product
{
    public class ProductFeaturedVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public int SizeId { get; set; }
        public List<Size> Sizes { get; set; }
        public IEnumerable<int> Product_sizeList { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
