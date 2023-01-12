using System.ComponentModel.DataAnnotations;

namespace End_Project.Models
{
    public class Contact : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
