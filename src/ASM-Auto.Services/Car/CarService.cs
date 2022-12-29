using ASM_Auto.Data.Models.Car;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace ASM_Auto.Services.Car
{
    public class CarService : ICarService
    {
        private IRepository<CarMake> carMakeRepository;
        private IRepository<CarModel> carModelRepository;

        public CarService(IRepository<CarMake> carMakeRepository
            , IRepository<CarModel> carModelRepository)
        {
            this.carMakeRepository = carMakeRepository;
            this.carModelRepository = carModelRepository;
        }

        public async Task<List<CarMake>> CarMakes()
        {
            var makes = await carMakeRepository.GetAll().ToListAsync();
            return makes;
        }

        public async Task<List<CarModel>> CarModels(int carMakeId)
        {
            var models = await carModelRepository.GetAll()
                .Where(c => c.CarMakeId == carMakeId)
                .ToListAsync();

            return models;
        }
    }
}
