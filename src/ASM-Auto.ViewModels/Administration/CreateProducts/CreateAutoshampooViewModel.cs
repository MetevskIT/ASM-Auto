using ASM_Auto.Data.Models.Products.Foil;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Administration.CreateProducts
{
    public class CreateAutoshampooViewModel
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; } = 50;
        [Required]
        public string? Description { get; set; }

        public string? LineDescription { get; set; }
        [Required]
        public bool FreeDelivery { get; set; } = false;
        [Required]
        public bool IsActive { get; set; } = true;
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}
