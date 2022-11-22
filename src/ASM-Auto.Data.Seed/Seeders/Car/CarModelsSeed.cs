using ASM_Auto.Data.Models.Car;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed
{
    public class CarModelsSeed : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.CarsModels.Any())
            {
                return;
            }

            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 1, CarModelText = "A3" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 1, CarModelText = "A4" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 1, CarModelText = "A5" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 1, CarModelText = "A6" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 1, CarModelText = "RS6" });
                                     
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 2, CarModelText = "320" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 2, CarModelText = "330" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 2, CarModelText = "525" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 2, CarModelText = "530" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 2, CarModelText = "645" });
                                     
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 3, CarModelText = "Model 3" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 3, CarModelText = "Model S" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 3, CarModelText = "Model X" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 3, CarModelText = "Model Y" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 3, CarModelText = "Model Y+" });
                                     
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 4, CarModelText = "812 Superfast" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 4, CarModelText = "Portofino M" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 4, CarModelText = "Roma" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 4, CarModelText = "Monza SP1" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 4, CarModelText = "Monza SP2" });
                                     
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 5, CarModelText = "Kuga" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 5, CarModelText = "Focus" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 5, CarModelText = "Mondeo" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 5, CarModelText = "Mustang" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 5, CarModelText = "Fiesta" });
                                     
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 6, CarModelText = "911 Carrera" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 6, CarModelText = "911 Turbo" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 6, CarModelText = "911 Turbo S" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 6, CarModelText = "911 GT3" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 6, CarModelText = "911 GT3 RS" });
                                     
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 7, CarModelText = "Accord" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 7, CarModelText = "Jazz" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 7, CarModelText = "Civic" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 7, CarModelText = "HR-V" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 7, CarModelText = "CR-V" });
                                     
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 8, CarModelText = "Golf MK4" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 8, CarModelText = "Tiguan" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 8, CarModelText = "Passat" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 8, CarModelText = "Tuareg" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 8, CarModelText = "Sharan" });
                                     
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 9, CarModelText = "Avalon" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 9, CarModelText = "Camry" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 9, CarModelText = "Corolla" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 9, CarModelText = "Yaris" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 9, CarModelText = "C-HR" });
                                     
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 10, CarModelText = "Huracan" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 10, CarModelText = "Urus" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 10, CarModelText = "Aventador" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 10, CarModelText = "Gallardo" });
            await dbContext.CarsModels.AddAsync(new CarModel { CarMakeId = 10, CarModelText = "Veneno" });

            await dbContext.SaveChangesAsync();
        }
    }
}
