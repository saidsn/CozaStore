using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace End_Project.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public DateTime CreateDate { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int BrendId { get; set; }

        public Brend Brend { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<ProductSize> ProductSizes { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
