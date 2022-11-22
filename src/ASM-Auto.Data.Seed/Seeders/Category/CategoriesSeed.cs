using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Category
{
    public class CategoriesSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { CategoryName = "AutoAccessories" });
            await dbContext.Categories.AddAsync(new Category { CategoryName = "AutoCosmetics" });
            await dbContext.Categories.AddAsync(new Category { CategoryName = "Multimedia" });

            await dbContext.SaveChangesAsync();

        }
    }
}
