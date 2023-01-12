using End_Project.Models;
using System.Collections.Generic;

namespace End_Project.ViewModels
{
    public class BlogDetailVM
    {
        public IEnumerable<Header> Headers { get; set; }
        public Blog Blog { get; set; }
        public IEnumerable<BlogCategory> BlogCategories { get; set; }
        public IEnumerable<Blog> RecentPosts { get; set; }
        public List<Tag> Tags { get; set; }
        public BlogComment BlogComment { get; set; }
        public IEnumerable<BlogComment> BlogComments { get; set; }
    }
}
