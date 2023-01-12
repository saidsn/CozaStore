using End_Project.Models;
using System.Collections.Generic;

namespace End_Project.ViewModels
{
    public class ContactVM
    {
        public IEnumerable<Header> Headers { get; set; }
        public Contact Contact { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Map Map { get; set; }
    }
}
