using End_Project.Models;
using System.Collections.Generic;

namespace End_Project.ViewModels
{
    public class AboutVM
    {
        public IEnumerable<Header> Headers { get; set; }
        public IEnumerable<About> Abouts { get; set; }
    }
}
