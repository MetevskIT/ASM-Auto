using ASM_Auto.Data.Models.Products.Foil;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Administration.EditProducts
{
    public class EditAutoshampooViewModel
    {
        [Key]
        public Guid productId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        [Range(0.00,9999.00)]
        public decimal Price { get; set; }

        [Range(0.00, 9999.00)]
        public decimal? NewPrice { get; set; }
        [Required]
        public int Quantity { get; set; } = 50;
        [Required]
        [StringLength(200,MinimumLength =5)]
        public string? Description { get; set; }
        public string? LineDescription { get; set; }
        [Required]
        public bool FreeDelivery { get; set; } = false;
        [Required]
        public bool IsActive { get; set; } = true;
        public List<IFormFile>? Images { get; set; } = new List<IFormFile>();
    }
}
