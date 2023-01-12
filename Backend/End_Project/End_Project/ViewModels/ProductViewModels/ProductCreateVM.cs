using End_Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace End_Project.ViewModels.Product
{
    public class ProductCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
        public int SizeId { get; set; }
        public List<Size> Size { get; set; }
        public IEnumerable<int> Products_sizeList { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
