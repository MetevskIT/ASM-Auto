using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Foil
{
    public class FoilsColorSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.FoilsColor.Any())
            {
                return;
            }

            await dbContext.FoilsColor.AddAsync(new FoilsColor { FoilColor = "Black" });
            await dbContext.FoilsColor.AddAsync(new FoilsColor { FoilColor = "White" });
            await dbContext.FoilsColor.AddAsync(new FoilsColor { FoilColor = "Blue" });
            await dbContext.FoilsColor.AddAsync(new FoilsColor { FoilColor = "Yellow" });
            await dbContext.FoilsColor.AddAsync(new FoilsColor { FoilColor = "Red" });
            await dbContext.FoilsColor.AddAsync(new FoilsColor { FoilColor = "Green" });

            await dbContext.SaveChangesAsync();

        }
    }
}
