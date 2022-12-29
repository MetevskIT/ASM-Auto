using ASM_Auto.Data.Models.Car;
using ASM_Auto.Data.Models.Enums.Products;

namespace ASM_Auto.ViewModels.Multimedia
{
    public class MultimediaQueryModel
    {
        public int currentPage { get; set; } = 1;

        public const int productsPerPage = 20;

        public int ProductCount { get; set; }

        public int? CarMakeId { get; set; }
        public int? CarModelId { get; set; }

        public IEnumerable<CarMake>? CarMakes { get; set; }
        public IEnumerable<CarModel>? CarModels { get; set; }
        public OrderedProducts OrderedProducts { get; set; }
        public IEnumerable<PartialProductModel>? Products { get; set; }

    }
}
