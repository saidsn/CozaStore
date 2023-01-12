using End_Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace End_Project.ViewModels.BlogViewModels
{
    public class BlogListVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public string BlogCategory { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
