using ASM_Auto.Data.Models.Car;

namespace ASM_Auto.Services.Common
{
    public interface ICarService
    {
        public Task<List<CarMake>> CarMakes();
        public Task<List<CarModel>> CarModels(int carMakeId);

    }
}
