using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Products = new List<CartProduct>();
        }
        [Key]
        public Guid CartId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<CartProduct> Products { get; set; }
    }
}
