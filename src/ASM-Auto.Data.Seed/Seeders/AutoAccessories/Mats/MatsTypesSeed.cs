using ASM_Auto.Data.Models.Products.AutoAccessories.Mats;
using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.AutoAccessories.Mats
{
    public class MatsTypesSeed :ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.MatsTypes.Any())
            {
                return;
            }

            await dbContext.MatsTypes.AddAsync(new MatsType { MatsTypeName = "Gumeni" });
            await dbContext.MatsTypes.AddAsync(new MatsType { MatsTypeName = "Kojeni" });
            await dbContext.MatsTypes.AddAsync(new MatsType { MatsTypeName = "Textil" });


            await dbContext.SaveChangesAsync();
        }
    }
}
