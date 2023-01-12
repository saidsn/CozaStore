using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace End_Project.ViewModels.BlogViewModels
{
    public class BlogEditVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BlogCategoryId { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
