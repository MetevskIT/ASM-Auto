using ASM_Auto.Data.Models;
using ASM_Auto.Data.Models.Enums.Products;
using ASM_Auto.Data.Models.Products.Foil;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using ASM_Auto.Services.ImageService;
using ASM_Auto.ViewModels;
using ASM_Auto.ViewModels.Administration.CreateProducts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.AutoAccessoriesServices
{
    public class FoilsService : IFoilService
    {
        private IRepository<Product> repository;
        private IRepository<FoilsType> foilsTypeRepository;
        private IRepository<FoilsPurpose> foilsPurposeRepository;
        private IRepository<FoilsColor> foilsColorRepository;
        private IImageService imageService;

        public FoilsService(
         IRepository<Product> repository,
         IRepository<FoilsType> foilsTypeRepository,
         IRepository<FoilsPurpose> foilsPurposeRepository,
         IRepository<FoilsColor> foilsColorRepository,
         IImageService imageService
            )
        {
            this.repository = repository;
            this.foilsPurposeRepository = foilsPurposeRepository;
            this.foilsTypeRepository = foilsTypeRepository;
            this.foilsColorRepository = foilsColorRepository;
            this.imageService = imageService;
        }

        public async Task CreateFoil(CreateFoilViewModel model)
        {
            var product = new Product
            {
                ProductTypeId = 2,
                Title = model.Title,
                Quantity = model.Quantity,
                Description = model.Description,
                Price = model.Price,
                IsActive = model.IsActive,

                LineDescription = model.LineDescription,
                FreeDelivery = model.FreeDelivery,
               FoilsPurposeId = model.FoilPurposeId,
               FoilsColorId = model.FoilColorId,
               FoilsTypeId = model.FoilType
            };

            foreach (var img in model.Images)
            {
                product.Images.Add(await imageService.UploadImage(img));

            }
            await repository.AddAsync(product);
            await repository.SaveChangesAsync();
        }

        public async Task<List<PartialProductModel>> GetFoils(int currentPage = 1, int? foilTypeId = null, int? ColorId = null, int? purposeId = null, OrderedProducts sorting = OrderedProducts.Newest, int productsPerPage = 20)
        {
            var products = new List<PartialProductModel>();

            var query = repository.GetAll()
                .Include(t => t.ProductType)
                .Include(i=>i.Images)
                .Where(f => f.ProductType.Type == "Foil")
                .Where(f => f.IsActive == true);

            if (foilTypeId!=null)
            {
                query = query.Where(ft => ft.FoilsTypeId == foilTypeId);
            }
            if (ColorId != null)
            {
                query = query.Where(c => c.FoilsColorId == ColorId);
            }
            if (purposeId != null)
            {
                query = query.Where(p => p.FoilsPurposeId == purposeId);
            }

            switch (sorting)
            {
                case OrderedProducts.PriceLowest:
                    query = query.OrderByDescending(l => l.Price);
                    break;
                case OrderedProducts.PriceHighest:
                    query = query.OrderBy(l => l.Price);
                    break;
                default:
                    query = query.OrderByDescending(l => l.AddDate);
                    break;
            }

            products = await query
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new PartialProductModel
                {
                    Title = p.Title,
                    Description = p.Description,
                    FreeDelivery = p.FreeDelivery,
                    ImageUrl = p.Images.FirstOrDefault().ImageUrl,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity,
                    ProductTypeId = p.ProductTypeId
                }).ToListAsync();
            return products;
        }

        public async Task<List<FoilsColor>> GetFoilsColors()
        {
            return await foilsColorRepository.GetAll().ToListAsync();
        }

        public Task<int> GetFoilsCount()
        {
            return repository.GetAll()
                .Include(t=>t.ProductType)
                .Where(f=>f.ProductType.Type=="Foils")
                .AsQueryable()
                .CountAsync();
        }

        public async Task<List<FoilsPurpose>> GetFoilsPurposes()
        {
            return await foilsPurposeRepository.GetAll().ToListAsync();
        }

        public async Task<List<FoilsType>> GetTypes()
        {
            return await foilsTypeRepository.GetAll().ToListAsync();
        }
    }
}
