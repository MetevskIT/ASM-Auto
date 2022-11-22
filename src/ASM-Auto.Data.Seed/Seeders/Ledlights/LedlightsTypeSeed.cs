using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Ledlights
{
    public class LedlightsTypeSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.LedlightsTypes.Any())
            {
                return;
            }

            await dbContext.LedlightsTypes.AddAsync(new LedlightsType { LedlightType = "Led" });
            await dbContext.LedlightsTypes.AddAsync(new LedlightsType { LedlightType = "Xenon" });
            await dbContext.LedlightsTypes.AddAsync(new LedlightsType { LedlightType = "Holagen" });

            await dbContext.SaveChangesAsync();
        }
    }
}
