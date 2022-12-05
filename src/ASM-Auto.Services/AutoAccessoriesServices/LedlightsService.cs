using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.Ledlights;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.Web.ViewModels.AutoAccessories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.AutoAccessoriesServices
{
    public class LedlightsService :ILedlightsService
    {
        public readonly IRepository<Product> repository;
        public readonly IRepository<LedlightsType> ledLightsTypeRepo;
        public readonly IRepository<LedlightsPower> ledLightsPowerRepo;
        public readonly IRepository<LedlightsModel> ledLightsModelRepo;
        public readonly IRepository<LedlightsFormat> ledLightsFormatRepo;
        public readonly IRepository<LedlightsColor> ledLightsColortRepo;
        public LedlightsService(
            IRepository<Product> repository,
            IRepository<LedlightsType> ledLightsTypeRepo,
            IRepository<LedlightsPower> ledLightsPowerRepo,
            IRepository<LedlightsModel> ledLightsModelRepo,
            IRepository<LedlightsFormat> ledLightsFormatRepo,
            IRepository<LedlightsColor> ledLightsColortRepo
            )
        {

            this.repository = repository;
            this.ledLightsFormatRepo = ledLightsFormatRepo;
            this.ledLightsModelRepo = ledLightsModelRepo;
            this.ledLightsColortRepo = ledLightsColortRepo;
            this.ledLightsPowerRepo = ledLightsPowerRepo;
            this.ledLightsTypeRepo = ledLightsTypeRepo;

        }
        public async Task<int> GetLedlightsCount() 
        {
           return repository
                  .GetAll()
                  .Where(t => t.ProductType.Type == "Ledlights")
                  .AsQueryable()
                  .Count();
        }
        public async Task<IEnumerable<LedlightsModel>> GetLedlights(
            int currentPage = 1,
            string? ledlightsType = null,
            string? ledlightsColor = null,
            string? ledlightsPower = null,
            string? ledlightsFormat = null,
            OrderedProducts sorting = OrderedProducts.Newest,
            int productsPerPage = 20)
        {
 
            var result = new List<LedlightsModel>();

            var ledlights = this.repository.GetAll()
                .Where(p=>p.ProductType.Type == "Ledlights")
                .Where(p => p.IsActive);

            if (!String.IsNullOrEmpty(ledlightsType))
            {
                ledlights = ledlights.Where(l =>l.LedlightsType.LedlightType==ledlightsType);
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
                .Skip((currentPage-1)*productsPerPage)
                .Take(productsPerPage)
                .Select(p => new LedlightsModel
            {
                LedlightId = p.ProductId,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                FreeDelivery = p.FreeDelivery,
                ImageUrl = p.ImageUrl,
                IsActive = p.IsActive,
                Quantity = p.Quantity,
                ProductTypeId = p.ProductTypeId,
                LedlightsColorId = p.LedlightsColorId,
                LedlightsFormatId = p.LedlightsFormatId,
                LedlightsPowerId = p.LedlightsPowerId,
                LedlightsTypeId = p.LedlightsTypeId

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

    }
}
