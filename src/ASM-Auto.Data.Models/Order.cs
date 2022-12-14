using ASM_Auto.Data.Models.Enums.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderedProducts = new List<OrderProduct>();
            this.OrderedOn = DateTime.Now;
            this.Status = OrderStatus.Pending;
        }

        [Key]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime OrderedOn { get; set; }
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
        public OrderStatus Status { get; set; }

        [Required]
        public ICollection<OrderProduct> OrderedProducts { get; set; }
    }
}
