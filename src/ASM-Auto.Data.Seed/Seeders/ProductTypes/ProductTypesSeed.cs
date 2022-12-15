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
            await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "Ledlights" });
            await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "Foil" });
           // await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "Interior" });
           // await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "Exterior" });
            await dbContext.AddAsync(new ProductType { CategoryId = 1, Type = "Mats" });

            //Seed AutoCosmetics Types
            await dbContext.AddAsync(new ProductType { CategoryId = 2, Type = "Autoshampoo" });
            await dbContext.AddAsync(new ProductType { CategoryId = 2, Type = "CleaningTools" });
           // await dbContext.AddAsync(new ProductType { CategoryId = 2, Type = "PolishingPastes" });
           // await dbContext.AddAsync(new ProductType { CategoryId = 2, Type = "CleaningProducts" });
           // await dbContext.AddAsync(new ProductType { CategoryId = 2, Type = "Flavorings" });

            //Seed Multimedia Types
            await dbContext.AddAsync(new ProductType { CategoryId = 3, Type = "Multimedia" });
            await dbContext.AddAsync(new ProductType { CategoryId = 3, Type = "BackupCameras" });
           // await dbContext.AddAsync(new ProductType { CategoryId = 3, Type = "DashCams" });

            await dbContext.SaveChangesAsync();

        }
    }
}
