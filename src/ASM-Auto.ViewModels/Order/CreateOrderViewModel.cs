using ASM_Auto.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Order
{
    public class CreateOrderViewModel
    {

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
    }
}
