using ASM_Auto.Data.Models;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.ProductTypes
{
    public class ProductTypesSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.ProductTypes.Any())
            {
                return;
            }
            //Seed Autoaccessories Types
            await dbContext.AddAsync(new ProductType { CategoryId = 0, Type = "Ledlights" });
            await dbContext.AddAsync(new ProductType { CategoryId = 0, Type = "Foil" });
            await dbContext.AddAsync(new ProductType { CategoryId = 0, Type = "Interior" });
            await dbContext.AddAsync(new ProductType { CategoryId = 0, Type = "Exterior" });
            await dbContext.AddAsync(new ProductType { CategoryId = 0, Type = "Mats" });

            //Seed AutoCosmetics Types
            await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "Autoshampoo" });
            await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "CleaningTools" });
            await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "PolishingPastes" });
            await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "CleaningProducts" });
            await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "Flavorings" });

            //Seed Multimedia Types
            await dbContext.AddAsync(new ProductType { CategoryId = 2, Type = "Multimedia" });
            await dbContext.AddAsync(new ProductType { CategoryId = 2, Type = "BackupCameras" });
            await dbContext.AddAsync(new ProductType { CategoryId = 2, Type = "DashCams" });

            await dbContext.SaveChangesAsync();

        }
    }
}
