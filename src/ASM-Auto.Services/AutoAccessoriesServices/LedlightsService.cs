using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using ASM_Auto.ViewModels.Administration.EditProducts;
using ASM_Auto.ViewModels.AutoAccessories.LedLights;
using Microsoft.EntityFrameworkCore;

namespace ASM_Auto.Services.AutoAccessoriesServices
{
    public class LedlightsService : ILedlightsService
    {
        public readonly IRepository<Product> repository;
        public readonly IRepository<LedlightsType> ledLightsTypeRepo;
        public readonly IRepository<LedlightsPower> ledLightsPowerRepo;
        public readonly IRepository<LedlightsModel> ledLightsModelRepo;
        public readonly IRepository<LedlightsFormat> ledLightsFormatRepo;
        public readonly IRepository<LedlightsColor> ledLightsColortRepo;
        private readonly IImageService imageService;

        public LedlightsService(
            IRepository<Product> repository,
            IRepository<LedlightsType> ledLightsTypeRepo,
            IRepository<LedlightsPower> ledLightsPowerRepo,
            IRepository<LedlightsModel> ledLightsModelRepo,
            IRepository<LedlightsFormat> ledLightsFormatRepo,
            IRepository<LedlightsColor> ledLightsColortRepo,
            IImageService imageService)
        {
            this.repository = repository;
            this.ledLightsFormatRepo = ledLightsFormatRepo;
            this.ledLightsModelRepo = ledLightsModelRepo;
            this.ledLightsColortRepo = ledLightsColortRepo;
            this.ledLightsPowerRepo = ledLightsPowerRepo;
            this.ledLightsTypeRepo = ledLightsTypeRepo;
            this.imageService = imageService;
        }

        public Task<int> GetLedlightsCount()
        {
            return repository
                   .GetAll()
                   .Where(t => t.ProductType.Type == "Ledlights")
                   .AsQueryable()
                   .CountAsync();
        }
        public async Task<IEnumerable<PartialProductModel>> GetLedlights(
            int currentPage = 1,
            string? ledlightsType = null,
            string? ledlightsColor = null,
            string? ledlightsPower = null,
            string? ledlightsFormat = null,
            OrderedProducts sorting = OrderedProducts.Newest,
            int productsPerPage = 20)
        {
            var result = new List<PartialProductModel>();

            var ledlights = this.repository.GetAll()
                .Include(i => i.Images)
                .Where(p => p.ProductType.Type == "Ledlights")
                .Where(p => p.IsActive);

            if (!String.IsNullOrEmpty(ledlightsType))
            {
                ledlights = ledlights.Where(l => l.LedlightsType.LedlightType == ledlightsType);
            }

            if (!String.IsNullOrEmpty(ledlightsColor))
            {
                ledlights = ledlights.Where(l => l.LedlightsColor.LedlightColor == ledlightsColor);
            }

            if (!String.IsNullOrEmpty(ledlightsPower))
            {
                ledlights = ledlights.Where(l => l.LedlightsPower.LedlightPower == ledlightsPower);
            }

            if (!String.IsNullOrEmpty(ledlightsFormat))
            {
                ledlights = ledlights.Where(l => l.LedlightsFormat.LedlightFormat == ledlightsFormat);
            }

            switch (sorting)
            {
                case OrderedProducts.PriceLowest:
                    ledlights = ledlights.OrderByDescending(l => l.Price);
                    break;
                case OrderedProducts.PriceHighest:
                    ledlights = ledlights.OrderBy(l => l.Price);
                    break;
                default:
                    ledlights = ledlights.OrderByDescending(l => l.AddDate);
                    break;
            }

            result = await ledlights
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

            return result;
        }

        public async Task<IEnumerable<LedlightsColor>> GetLedlightsColors()
        {
            return this.ledLightsColortRepo.GetAll();
        }

        public async Task<IEnumerable<LedlightsFormat>> GetLedlightsFormats()
        {
            return this.ledLightsFormatRepo.GetAll();
        }

        public async Task<IEnumerable<LedlightsModel>> GetLedlightsModels()
        {
            return this.ledLightsModelRepo.GetAll();
        }

        public async Task<IEnumerable<LedlightsPower>> GetLedlightsPower()
        {
            return this.ledLightsPowerRepo.GetAll();
        }

        public async Task<IEnumerable<LedlightsType>> GetLedlightsTypes()
        {
            return this.ledLightsTypeRepo.GetAll();
        }

        public async Task CreateLedLight(CreateLedLightViewModel model)
        {
            var product = new Product
            {
                ProductTypeId = 1,
                Title = model.Title,
                Quantity = model.Quantity,
                Description = model.Description,
                Price = model.Price,
                IsActive = model.IsActive,
                LineDescription = model.LineDescription,
                FreeDelivery = model.FreeDelivery,
                LedlightsColorId = model.LedlightsColorId,
                LedlightsFormatId = model.LedlightsFormatId,
                LedlightsPowerId = model.LedlightsPowerId,
                LedlightsTypeId = model.LedlightsTypeId
            };

            foreach (var img in model.Images)
            {
                product.Images.Add(await imageService.UploadImage(img));
            }

            await repository.AddAsync(product);
            await repository.SaveChangesAsync();
        }

        public async Task EditLedLight(EditLedLightViewModel model)
        {
            var product = await repository.GetAll()
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
            product.LedlightsColorId = model.LedlightsColorId;
            product.LedlightsFormatId = model.LedlightsFormatId;
            product.LedlightsPowerId = model.LedlightsPowerId;
            product.LedlightsTypeId = model.LedlightsTypeId;

            if (model.Images.Any())
            {
                product.Images.Clear();

                await imageService.RemoveImages(product.ProductId);

                foreach (var img in model.Images)
                {
                    product.Images.Add(await imageService.UploadImage(img));
                }
            }

            await repository.SaveChangesAsync();
        }
    }
}
