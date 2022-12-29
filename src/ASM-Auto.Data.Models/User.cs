using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Auto.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(Cart))]
        public Guid? CartId { get; set; }
        public Cart? Cart { get; set; }

        public ICollection<Product> LikedProducts { get; set; } = new List<Product>();

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
