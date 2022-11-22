using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Interior
{
    public class InteriorsAccessoriesSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.InteriorsAccessories.Any())
            {
                return;
            }

            await dbContext.InteriorsAccessories.AddAsync(new InteriorsAccessory { InteriorAccessory = "CupHolders" });
            await dbContext.InteriorsAccessories.AddAsync(new InteriorsAccessory { InteriorAccessory = "PhoneHolders" });
            await dbContext.InteriorsAccessories.AddAsync(new InteriorsAccessory { InteriorAccessory = "SportsPedals" });
            await dbContext.InteriorsAccessories.AddAsync(new InteriorsAccessory { InteriorAccessory = "ShiftKnobs" });
            await dbContext.InteriorsAccessories.AddAsync(new InteriorsAccessory { InteriorAccessory = "CupHolder" });

            await dbContext.SaveChangesAsync();

        }
    }
}
