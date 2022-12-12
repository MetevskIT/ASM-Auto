using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels
{
    public class DetailsViewModel
    {
        [Required]
        public Guid productId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? ImagesUrl { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public decimal? Price { get; set; }

        public decimal? NewPrice { get; set; }

        public string? Make { get; set; }

        public string? Model { get; set; }

        [Required]
        public string? Description { get; set; }

        public string? LineDescription { get; set; }

        [Required]
        public bool IsLiked { get; set; }

        [Required]
        public bool IsFreeDelivery { get; set; }
    }
}
