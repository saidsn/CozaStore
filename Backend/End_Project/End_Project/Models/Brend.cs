using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace End_Project.Models
{
    public class Brend : BaseEntity
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Can't be empty")]
        public IFormFile Photo { get; set; }

    }
}
