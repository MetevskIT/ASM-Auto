using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.Cart
{
    public class CartViewModel
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
