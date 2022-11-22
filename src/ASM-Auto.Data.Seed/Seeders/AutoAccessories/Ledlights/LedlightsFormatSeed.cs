using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Ledlights
{
    public class LedlightsFormatSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.LedlightsFormats.Any())
            {
                return;
            }

            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "C3W" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H1" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H3" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H4" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H6W" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H7" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H8" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H9" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H10" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H10W" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H11" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H15" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H16" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "H21W" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "T4W" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "W5W" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "D1R" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "D1S" });
            await dbContext.LedlightsFormats.AddAsync(new LedlightsFormat { LedlightFormat = "D2R" });

            await dbContext.SaveChangesAsync();
        }
    }
}
