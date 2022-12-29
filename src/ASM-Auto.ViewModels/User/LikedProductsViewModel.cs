using System.ComponentModel.DataAnnotations;

namespace ASM_Auto.ViewModels.User
{
    public class LikedProductsViewModel
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string? ImageUrl { get; set; }
    }
}
