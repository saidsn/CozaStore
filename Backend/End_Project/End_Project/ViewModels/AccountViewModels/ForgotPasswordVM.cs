using System.ComponentModel.DataAnnotations;

namespace End_Project.ViewModels.AccountViewModels
{
    public class ForgotPasswordVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
