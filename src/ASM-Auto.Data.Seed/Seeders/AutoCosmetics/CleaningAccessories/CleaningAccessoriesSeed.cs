using ASM_Auto.Data.Models.Products.AutoCosmetics;
using ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.AutoCosmetics.CleaningAccessories
{
    public class CleaningAccessoriesSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.CleaningAccessories.Any())
            {
                return;
            }

            await dbContext.CleaningAccessories.AddAsync(new CleaningAccessory { CleaningAccessoryName = "Sponge" });
            await dbContext.CleaningAccessories.AddAsync(new CleaningAccessory { CleaningAccessoryName = "Brushes" });
            await dbContext.CleaningAccessories.AddAsync(new CleaningAccessory { CleaningAccessoryName = "МicrofibreTowel" });
            await dbContext.CleaningAccessories.AddAsync(new CleaningAccessory { CleaningAccessoryName = "Chamois" });

            await dbContext.SaveChangesAsync();
        }
    }
}
