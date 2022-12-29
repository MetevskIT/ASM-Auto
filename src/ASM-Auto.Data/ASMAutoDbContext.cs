using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Car;
using ASM_Auto.Data.Models.Products.AutoAccessories.Mats;
using ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories;
using ASM_Auto.Data.Models.Products.Exterior;
using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.Data.Models.Products.Interior;
using ASM_Auto.Data.Models.Products.Ledlights;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASM_Auto.Data
{
    public class ASMAutoDbContext : IdentityDbContext<User>
    {
        public ASMAutoDbContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LedlightsType> LedlightsTypes { get; set; }
        public DbSet<LedlightsColor> LedlightsColors { get; set; }
        public DbSet<LedlightsPower> LedlightsPowers { get; set; }
        public DbSet<LedlightsFormat> LedlightsFormats { get; set; }
        public DbSet<FoilsType> FoilsTypes { get; set; }
        public DbSet<FoilsColor> FoilsColor { get; set; }
        public DbSet<FoilsPurpose> FoilsPurpose { get; set; }
        public DbSet<InteriorsAccessory> InteriorsAccessories { get; set; }
        public DbSet<ExteriorsAccessory> ExteriorsAccessories { get; set; }
        public DbSet<MatsType> MatsTypes { get; set; }
        public DbSet<CarMake> CarsMakes { get; set; }
        public DbSet<CarModel> CarsModels { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CleaningAccessory> CleaningAccessories { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasMany<Product>(p => p.LikedProducts)
               .WithMany(u => u.Liked);

            modelBuilder.Entity<User>()
               .HasOne<Cart>(c => c.Cart)
               .WithOne(c => c.User)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartProduct>()
                .HasKey(pk => new { pk.CartId, pk.ProductId });

            modelBuilder.Entity<OrderProduct>()
              .HasKey(pk => new { pk.OrderId, pk.ProductId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
