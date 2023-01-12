using End_Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace End_Project.ViewModels.BlogViewModels
{
    public class BlogCreateVM
    {
     
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        public DateTime CreateDate { get; set; }
        public int BlogCategoryId { get; set; }
        public int TagId { get; set; }
        public List<Tag> Tag { get; set; }
        public IEnumerable<int> Blog_TagList { get; set; }
    }
}
