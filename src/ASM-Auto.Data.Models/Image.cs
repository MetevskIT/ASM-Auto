using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string? ImageUrl { get; set; }


        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
