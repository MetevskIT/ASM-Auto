using ASM_Auto.Data.Models;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Categories
{
    public class CategoriesSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }
          
            await dbContext.Categories.AddAsync(new Category { CategoryName = "Автоаксесоари" });
            await dbContext.Categories.AddAsync(new Category { CategoryName = "Автокозметика" });
            await dbContext.Categories.AddAsync(new Category { CategoryName = "Мултимедии" });

            await dbContext.SaveChangesAsync();

        }
    }
}
