using End_Project.Models;
using System.Collections.Generic;

namespace End_Project.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<Models.Product> Products { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Brend> Brends { get; set; }

    }
}
