using ASM_Auto.Data;
using ASM_Auto.Data.Models.Car;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed
{
    public class CarMakesSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.CarsMakes.Any())
            {
                return;
            }

            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "Audi" });
            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "BMW" });
            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "Tesla" });
            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "Ferrari" });
            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "Ford" });
            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "Porsche" });
            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "Honda" });
            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "VW" });
            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "Toyota" });
            await dbContext.CarsMakes.AddAsync(new CarMake { CarMakeText = "Lamborghini" });
           
            await dbContext.SaveChangesAsync();

        }
    }
}
