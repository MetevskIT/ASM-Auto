using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Ledlights
{
    public class LedlightsColorSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.LedlightsColors.Any())
            {
                return;
            }

            await dbContext.LedlightsColors.AddAsync(new LedlightsColor { LedlightColor = "Red" });
            await dbContext.LedlightsColors.AddAsync(new LedlightsColor { LedlightColor = "Yellow" });
            await dbContext.LedlightsColors.AddAsync(new LedlightsColor { LedlightColor = "Blue" });
            await dbContext.LedlightsColors.AddAsync(new LedlightsColor { LedlightColor = "RGB" });

            await dbContext.SaveChangesAsync();
        }
    }
}
