using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [Required]
        [PasswordPropertyText]
        public string? OldPassword { get; set; }

        [Required]
        [PasswordPropertyText]
        [StringLength(20,MinimumLength =5)]
        public string? NewPassword { get; set; }

        [Required]
        [PasswordPropertyText]
        [Compare(nameof(NewPassword))]
        public string? ConfirmNewPassword { get; set; }
    }
}
