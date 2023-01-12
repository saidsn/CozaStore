using System.Collections.Generic;

namespace End_Project.Models
{
    public class BlogCategory : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
