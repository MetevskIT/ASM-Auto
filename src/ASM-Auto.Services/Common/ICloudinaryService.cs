using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ASM_Auto.Services.Common
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile image, string imageId);

    }
}
