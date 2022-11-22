using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Foil
{
    public class FoilsPurposeSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.FoilsPurpose.Any())
            {
                return;
            }

            await dbContext.FoilsPurpose.AddAsync(new FoilsPurpose { FoilPurpose = "Windows" });
            await dbContext.FoilsPurpose.AddAsync(new FoilsPurpose { FoilPurpose = "Headtights" });
            await dbContext.FoilsPurpose.AddAsync(new FoilsPurpose { FoilPurpose = "External" });

            await dbContext.SaveChangesAsync();

        }
    }
}
