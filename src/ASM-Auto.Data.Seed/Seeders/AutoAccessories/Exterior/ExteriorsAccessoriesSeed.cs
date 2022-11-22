using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Products.Exterior;
using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Exterior
{
    public class ExteriorsAccessoriesSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.ExteriorsAccessories.Any())
            {
                return;
            }

            await dbContext.ExteriorsAccessories.AddAsync(new ExteriorsAccessory { ExteriorAccessory = "CupHolders" });
            await dbContext.ExteriorsAccessories.AddAsync(new ExteriorsAccessory { ExteriorAccessory = "PhoneHolders" });
            await dbContext.ExteriorsAccessories.AddAsync(new ExteriorsAccessory { ExteriorAccessory = "SportsPedals" });
            await dbContext.ExteriorsAccessories.AddAsync(new ExteriorsAccessory { ExteriorAccessory = "ShiftKnobs" });
            await dbContext.ExteriorsAccessories.AddAsync(new ExteriorsAccessory { ExteriorAccessory = "CupHolder" });

            await dbContext.SaveChangesAsync();

        }
    }
}
