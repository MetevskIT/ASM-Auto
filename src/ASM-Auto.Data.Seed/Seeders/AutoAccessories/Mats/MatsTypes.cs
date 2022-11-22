using ASM_Auto.Data.Models.Products.AutoAccessories.Mats;
using ASM_Auto.Data.Models.Products.Ledlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.AutoAccessories.Mats
{
    public class MatsTypes
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.MatsTypes.Any())
            {
                return;
            }

            await dbContext.MatsTypes.AddAsync(new MatsType { MatsTypeName = "Rubber" });
            await dbContext.MatsTypes.AddAsync(new MatsType { MatsTypeName = "Leather" });
            await dbContext.MatsTypes.AddAsync(new MatsType { MatsTypeName = "Textile" });


            await dbContext.SaveChangesAsync();
        }
    }
}
