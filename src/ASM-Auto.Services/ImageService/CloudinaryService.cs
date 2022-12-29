using ASM_Auto.Services.Common;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ASM_Auto.Services.ImageService
{
    public class CloudinaryService : ICloudinaryService
    {
        private Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile image, string imageId)
        {
            using var stream = image.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageId, stream),
                Folder = "Images",
            };

            return await this.cloudinary.UploadAsync(uploadParams);
        }
    }
}
