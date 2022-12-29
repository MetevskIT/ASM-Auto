using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(25,MinimumLength=6)]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [PasswordPropertyText]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
