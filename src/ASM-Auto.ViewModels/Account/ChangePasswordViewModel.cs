using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [Required]
        [PasswordPropertyText]
        public string? OldPassword { get; set; }


        [Required]
        [PasswordPropertyText]
        public string? NewPassword { get; set; }

        [Required]
        [PasswordPropertyText]
        [Compare(nameof(NewPassword))]
        public string? ConfirmNewPassword { get; set; }
    }
}
