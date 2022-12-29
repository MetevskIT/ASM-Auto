using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.AutoAccessories.Mats;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using ASM_Auto.ViewModels.Administration.EditProducts;
using Microsoft.EntityFrameworkCore;

namespace ASM_Auto.Services.AutoAccessoriesServices
{
    public class MatsService : IMatsService
    {
        private IRepository<MatsType> matsTypesRepository;
        private IRepository<Product> matsRepository;
        private IImageService imageService;

        public MatsService(
            IRepository<MatsType> matsTypesRepository,
            IRepository<Product> matsRepository,
            IImageService imageService)
        {
            this.matsRepository = matsRepository;
            this.matsTypesRepository = matsTypesRepository;
            this.imageService = imageService;
        }

        public async Task CreateMat(CreateMatViewModel model)
        {
            var product = new Product
            {
                ProductTypeId = 3,
                Title = model.Title,
                Quantity = model.Quantity,
                Description = model.Description,
                Price = model.Price,
                IsActive = model.IsActive,
                LineDescription = model.LineDescription,
                FreeDelivery = model.FreeDelivery,
                CarMakeId = model.CarMakeId,
                CarModelId = model.CarModelId,
                MatsTypeId = model.MatTypeId
            };

            foreach (var img in model.Images)
            {
                product.Images.Add(await imageService.UploadImage(img));
            }

            await matsRepository.AddAsync(product);
            await matsRepository.SaveChangesAsync();
        }

        public async Task EditMat(EditMatViewModel model)
        {
            var product = await matsRepository.GetAll()
                .Where(i => i.ProductId == model.ProductId)
                .FirstOrDefaultAsync();

            product.Title = model.Title;
            product.Quantity = model.Quantity;
            product.Description = model.Description;
            product.Price = model.Price;
            product.NewPrice = model.NewPrice;
            product.IsActive = model.IsActive;
            product.LineDescription = model.LineDescription;
            product.FreeDelivery = model.FreeDelivery;
            product.CarMakeId = model.CarMakeId;
            product.CarModelId = model.CarModelId;
            product.MatsTypeId = model.MatTypeId;

            if (model.Images.Any())
            {
                product.Images.Clear();

                await imageService.RemoveImages(product.ProductId);

                foreach (var img in model.Images)
                {
                    product.Images.Add(await imageService.UploadImage(img));
                }
            }

            await matsRepository.SaveChangesAsync();
        }

        public async Task<List<PartialProductModel>> GetMats(int currentPage = 1, int? CarMakeId = null, int? CarModelId = null, int? MatTypeId = null, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20)
        {
            var products = new List<PartialProductModel>();

            var result = matsRepository.GetAll()
                .Include(i => i.Images)
                .Include(c => c.CarMake)
                .Include(cm => cm.CarModel)
                .Where(pt => pt.ProductType.Type == "Mats")
                .Where(p => p.IsActive == true);

            if (CarMakeId != null)
            {
                result = result.Where(c => c.CarMakeId == CarMakeId);
            }

            if (CarModelId != null)
            {
                result = result.Where(c => c.CarModelId == CarModelId);
            }

            if (MatTypeId != null)
            {
                result = result.Where(mt => mt.MatsTypeId == MatTypeId);
            }

            switch (sorting)
            {
                case OrderedProducts.PriceLowest:
                    result.OrderByDescending(p => p.Price);
                    break;
                case OrderedProducts.PriceHighest:
                    result.OrderBy(p => p.Price);
                    break;
                default:
                    result = result.OrderByDescending(l => l.AddDate);
                    break;
            }

            products = await result
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new PartialProductModel
                {
                    ProductId = p.ProductId,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    FreeDelivery = p.FreeDelivery,
                    ImageUrl = p.Images.FirstOrDefault().ImageUrl,
                    IsActive = p.IsActive,
                    Quantity = p.Quantity,
                    ProductTypeId = p.ProductTypeId
                }).ToListAsync();

            return products;
        }

        public Task<int> MatsCount()
        {
            return matsRepository.GetAll()
            .Where(m => m.ProductType.Type == "Mats")
            .AsQueryable()
            .CountAsync();
        }

        public async Task<List<MatsType>> MatsTypes()
        {
            var types = await matsTypesRepository.GetAll().ToListAsync();

            return types;
        }
    }
}
