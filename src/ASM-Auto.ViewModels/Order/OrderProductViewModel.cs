using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.Order
{
    public class OrderProductViewModel
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
