using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Products.Exterior;
using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.Data.Models.Products.Interior;
using ASM_Auto.Data.Models.Products.Ledlights;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data
{
    public class ASMAutoDbContext : IdentityDbContext<IdentityUser>
    {
        public ASMAutoDbContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<LedlightsType> LedlightsTypes { get; set; } = null!;
        public DbSet<LedlightsColor> LedlightsColors { get; set; } = null!;
        public DbSet<LedlightsPower> LedlightsPowers { get; set; } = null!;
        public DbSet<LedlightsFormat> LedlightsFormats { get; set; } = null!;
        public DbSet<FoilsType> FoilsTypes { get; set; } = null!;
        public DbSet<FoilsColor> FoilsColor { get; set; } = null!;
        public DbSet<FoilsPurpose> FoilsPurpose { get; set; } = null!;
        public DbSet<InteriorsAccessory> InteriorsAccessories { get; set; } = null!;
        public DbSet<ExteriorsAccessory> ExteriorsAccessories { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
