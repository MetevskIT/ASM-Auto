using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(25,MinimumLength=6)]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
