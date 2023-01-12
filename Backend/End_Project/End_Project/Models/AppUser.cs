using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace End_Project.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsActive { get; set; } = false;
        public Basket Basket { get; set; }

        public List<Comment> Comments { get; set; }
        public List<BlogComment> BlogComments { get; set; }

    }
}