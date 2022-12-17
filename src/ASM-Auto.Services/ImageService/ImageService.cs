using ASM_Auto.Data.Models;
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> imageRepository;
        private readonly ICloudinaryService cloudinaryService;

        public ImageService(
            IRepository<Image> imageRepository,
            ICloudinaryService cloudinaryService)
        {
            this.imageRepository = imageRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task RemoveImages(Guid productId)
        {
            var images = await imageRepository.GetAll()
                 .Include(p => p.Product)
                 .Where(p => p.ProductId == productId)
                 .ToListAsync();

             imageRepository.DeleteRange(images);
            await imageRepository.SaveChangesAsync();
        }

        public async Task<Image> UploadImage(IFormFile imageFile)
        {
            var image = new Image();

            var result = await this.cloudinaryService.UploadImageAsync(imageFile, image.ImageId.ToString());

            if (result.Error != null)
            {
                throw new InvalidOperationException(result.Error.Message);
            }

            image.ImageUrl = result.Url.ToString();

            await this.imageRepository.AddAsync(image);
            await this.imageRepository.SaveChangesAsync();

            return image;
        }
    }
}
