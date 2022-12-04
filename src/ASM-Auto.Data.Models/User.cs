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
    public class User : IdentityUser
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cart = new List<Product>();
            this.LikedProducts = new List<Product>();
            this.Orders = new List<Order>();
            this.Contacts = new List<Contact>();
        }

        public ICollection<Product> Cart { get; set; }
        public ICollection<Product> LikedProducts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
