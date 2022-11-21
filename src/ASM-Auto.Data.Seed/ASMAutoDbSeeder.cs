using ASM_Auto.Data.Seed.Common;
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

           // seeders.Add(new CarDoorsSeeder());
        

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext);
            }
        }
    }
}
