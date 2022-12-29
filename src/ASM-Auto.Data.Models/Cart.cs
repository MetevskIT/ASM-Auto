using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Auto.Data.Models
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }

        public ICollection<CartProduct> Products { get; set; } = new List<CartProduct>();
    }
}
