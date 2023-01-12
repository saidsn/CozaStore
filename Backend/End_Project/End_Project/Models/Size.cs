using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace End_Project.Models
{
    public class Size : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<ProductSize> ProductSizes { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
