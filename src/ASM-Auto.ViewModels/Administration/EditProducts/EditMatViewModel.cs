﻿using ASM_Auto.Data.Models.Car;
using ASM_Auto.Data.Models.Products.AutoAccessories.Mats;
using ASM_Auto.Data.Models.Products.Ledlights;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Administration.EditProducts
{
    public class EditMatViewModel
    {

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string? Title { get; set; }
        [Required]
        [Range(0.00, 9999.00)]
        public decimal Price { get; set; }
        [Range(0.00, 9999.00)]
        public decimal? NewPrice { get; set; }
        [Required]
        public int Quantity { get; set; } = 50;
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string? Description { get; set; }

        public string? LineDescription { get; set; }
        [Required]
        public bool FreeDelivery { get; set; } = false;
        [Required]
        public bool IsActive { get; set; } = true;
        public List<IFormFile>? Images { get; set; } = new List<IFormFile>();
        [Required]
        public int? MatTypeId { get; set; }
        [Required]
        public int? CarMakeId { get; set; }
        [Required]
        public int? CarModelId { get; set; }

        public IEnumerable<CarMake> CarMakes { get; set; } = new List<CarMake>();
        public IEnumerable<CarModel> CarModels { get; set; } = new List<CarModel>();
        public IEnumerable<MatsType> MatsTypes { get; set; } = new List<MatsType>();

    }
}