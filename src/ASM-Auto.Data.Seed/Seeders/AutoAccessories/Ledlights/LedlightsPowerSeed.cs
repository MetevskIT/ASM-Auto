using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Ledlights
{
    public class LedlightsPowerSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.LedlightsPowers.Any())
            {
                return;
            }

            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "1.5W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "2W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "3W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "4.8W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "8W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "15W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "26W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "35W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "40W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "55W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "65W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "70W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "100W" });
            await dbContext.LedlightsPowers.AddAsync(new LedlightsPower { LedlightPower = "120W" });

            await dbContext.SaveChangesAsync();
        }
    }
}
