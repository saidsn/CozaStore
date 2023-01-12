using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace End_Project.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
