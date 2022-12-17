using ASM_Auto.Data.Models;
using ASM_Auto.Data.Seed.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Test
{
    public class TestProducts : ISeeder
    {
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {

            await dbContext.AddAsync(new Product
            {
                Title = "asdasdasda",
                Quantity = 30,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 6,
                Price = 30,
                MatsTypeId = 1,
                CarMakeId = 1,
                CarModelId = 1
            });
            await dbContext.AddAsync(new Product
            {
                Title = "asdasdasda",
                Quantity = 30,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 7,
                Price = 30,
                MatsTypeId = 1,
                CarMakeId = 1,
                CarModelId = 1
            });



            await dbContext.AddAsync(new Product
            {
                Title = "asdasdasda",
                Quantity = 30,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 5,
                Price = 30,
                MatsTypeId = 1,
                CarMakeId = 1,
                CarModelId = 1
            });


            await dbContext.AddAsync(new Product
            {
                Title = "Test",
                Quantity = 50,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl= "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 2,
                Price = 30,
                LedlightsColorId = 1,
                LedlightsFormatId = 1,
                LedlightsPowerId = 1,
                LedlightsTypeId = 1
            }) ;
            await dbContext.AddAsync(new Product
            {
                Title = "Test2",
                Quantity = 50,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 2,
                Price = 50,
                LedlightsColorId = 2,
                LedlightsFormatId = 1,
                LedlightsPowerId = 4,
                LedlightsTypeId = 1
            });
            await dbContext.AddAsync(new Product
            {
                Title = "Test3",
                Quantity = 50,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 1,
                Price = 5,
                LedlightsColorId = 2,
                LedlightsFormatId = 2,
                LedlightsPowerId = 2,
                LedlightsTypeId = 1
            });
            await dbContext.AddAsync(new Product
            {
                Title = "Test4",
                Quantity = 50,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 1,
                Price = 50,
                LedlightsColorId = 1,
                LedlightsFormatId = 1,
                LedlightsPowerId = 1,
                LedlightsTypeId = 1
            });
            await dbContext.AddAsync(new Product
            {
                Title = "Test5",
                Quantity = 50,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 1,
                Price = 50,
                LedlightsColorId = 1,
                LedlightsFormatId = 1,
                LedlightsPowerId = 1,
                LedlightsTypeId = 1
            });
            await dbContext.AddAsync(new Product
            {
                Title = "Test6",
                Quantity = 50,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 1,
                Price = 50,
                LedlightsColorId = 1,
                LedlightsFormatId = 1,
                LedlightsPowerId = 1,
                LedlightsTypeId = 1
            });
            await dbContext.AddAsync(new Product
            {
                Title = "Test7",
                Quantity = 50,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 1,
                Price = 50,
                LedlightsColorId = 1,
                LedlightsFormatId = 1,
                LedlightsPowerId = 1,
                LedlightsTypeId = 1
            });
            await dbContext.AddAsync(new Product
            {
                Title = "Test8",
                Quantity = 50,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 1,
                Price = 50,
                LedlightsColorId = 1,
                LedlightsFormatId = 1,
                LedlightsPowerId = 1,
                LedlightsTypeId = 1
            });
            await dbContext.AddAsync(new Product
            {
                Title = "Test9",
                Quantity = 50,
                Description = "Test from database!!!!",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 1,
                Price = 50,
                LedlightsColorId = 1,
                LedlightsFormatId = 1,
                LedlightsPowerId = 1,
                LedlightsTypeId = 1
            });
            await dbContext.AddAsync(new Product
            {
                Title = "Test10",
                Quantity = 50,
                Description = "Test from database!!!!",
                LineDescription = "Test. Test2. Red2. Red3. Red4.",
                IsActive = true,
                FreeDelivery = true,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 1,
                Price = 50,
                LedlightsColorId = 1,
                LedlightsFormatId = 1,
                LedlightsPowerId = 1,
                LedlightsTypeId = 1,
                NewPrice = 50,
                CarMakeId =1,
                CarModelId = 1,
                IsAvailable=false

            });
            await dbContext.AddAsync(new Product
            {
                Title = "Test11",
                Quantity = 50,
                Description = "Test from database!!!! . RED2 . tEST 3 . RED 5 .",
                IsActive = true,
                FreeDelivery = false,
                ImageUrl = "https://d1hv7ee95zft1i.cloudfront.net/custom/blog-post-photo/gallery/xenon-hid-60d2ca5007b84.jpg",
                ProductTypeId = 2,
                Price = 50,
                LedlightsColorId = 2,
                LedlightsFormatId = 2,
                LedlightsPowerId = 2,
                LedlightsTypeId = 2,
                NewPrice = 200
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
