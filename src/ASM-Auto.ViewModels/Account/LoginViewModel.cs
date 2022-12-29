using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 6)]
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}
