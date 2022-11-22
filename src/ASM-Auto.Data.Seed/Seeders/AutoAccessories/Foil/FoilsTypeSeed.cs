using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Foil
{
    public class FoilsTypeSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.FoilsTypes.Any())
            {
                return;
            }

            await dbContext.FoilsTypes.AddAsync(new FoilsType { FoilType = "Matt" });
            await dbContext.FoilsTypes.AddAsync(new FoilsType { FoilType = "Glassy" });
            await dbContext.FoilsTypes.AddAsync(new FoilsType { FoilType = "Carbon" });
            await dbContext.FoilsTypes.AddAsync(new FoilsType { FoilType = "Camouflage" });

            await dbContext.SaveChangesAsync();

        }
    }
}
