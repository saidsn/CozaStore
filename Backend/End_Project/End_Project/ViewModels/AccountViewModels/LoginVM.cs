using System.ComponentModel.DataAnnotations;

namespace End_Project.ViewModels.AccountViewModels
{
    public class LoginVM
    {
        [Required]
        public string UserNameorEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
