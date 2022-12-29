using ASM_Auto.Data.Models.Enums.Order;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Auto.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime OrderedOn { get; set; } = DateTime.Now;
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

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Required]
        public ICollection<OrderProduct> OrderedProducts { get; set; } = new List<OrderProduct>();
    }
}
