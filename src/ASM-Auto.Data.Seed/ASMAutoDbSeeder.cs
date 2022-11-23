using ASM_Auto.Data.Seed.Common;
using ASM_Auto.Data.Seed.Seeders.AutoCosmetics;
using ASM_Auto.Data.Seed.Seeders.Categories;
using ASM_Auto.Data.Seed.Seeders.Exterior;
using ASM_Auto.Data.Seed.Seeders.Foil;
using ASM_Auto.Data.Seed.Seeders.Interior;
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

             seeders.Add(new ExteriorsAccessoriesSeed());
             seeders.Add(new ProductTypesSeed());
             seeders.Add(new LedlightsTypeSeed());
             seeders.Add(new LedlightsColorSeed());
             seeders.Add(new LedlightsPowerSeed());
             seeders.Add(new LedlightsFormatSeed());
             seeders.Add(new FoilsTypeSeed());
             seeders.Add(new FoilsColorSeed());
             seeders.Add(new FoilsPurposeSeed());
             seeders.Add(new InteriorsAccessoriesSeed());
             seeders.Add(new CategoriesSeed());
             seeders.Add(new CarMakesSeed());
             seeders.Add(new CarModelsSeed());

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext);
            }
        }
    }
}
