using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.Data.Seed.Common;
using ASM_Auto.Data.Seed.Seeders;
using ASM_Auto.Data.Seed.Seeders.Category;
using ASM_Auto.Data.Seed.Seeders.Ledlights;
using ASM_Auto.Data.Seed.Seeders.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed
{
    public class ASMAutoDbSeeder : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            var seeders = new List<ISeeder>();

             seeders.Add(new CategoriesSeed());
             seeders.Add(new ProductTypesSeed());
             seeders.Add(new LedlightsTypeSeed());
             seeders.Add(new LedlightsColorSeed());
             seeders.Add(new LedlightsPowerSeed());
             seeders.Add(new LedlightsFormatSeed());

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext);
            }
        }
    }
}
