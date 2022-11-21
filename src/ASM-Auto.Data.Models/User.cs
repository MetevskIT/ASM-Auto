using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid();
            //Cart = new List<Product>();
            //LikedProducts = new List<Product>();
            //Orders = new List<Order>();
            Contacts = new List<Contact>();
        }
        [Key]
        public Guid Id { get; set; }

        //public ICollection<Product> Cart { get; set; };
        //public ICollection<Product> LikedProducts { get; set; };
        //public ICollection<Order> Orders { get; set; }
        public ICollection<Contact> Contacts { get; set; }

        [Required]
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; } = null!;
        public IdentityUser IdentityUser { get; set; } = null!;
    }
}
