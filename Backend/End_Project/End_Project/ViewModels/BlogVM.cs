using End_Project.Models;
using System.Collections.Generic;

namespace End_Project.ViewModels
{
    public class BlogVM
    {
        public IEnumerable<Header> Headers { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<BlogCategory> BlogCategories { get; set; }
        public IEnumerable<Blog> RecentPosts { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
