using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.Order
{
    public class CreateOrderViewModel
    {

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Town { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
