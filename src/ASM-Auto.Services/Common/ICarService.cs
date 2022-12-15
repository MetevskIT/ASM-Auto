using ASM_Auto.Data.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{
    public interface ICarService
    {
        public Task<List<CarMake>> CarMakes();
        public Task<List<CarModel>> CarModels(int carMakeId);
    }
}
