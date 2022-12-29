using ASM_Auto.Data.Models;
using Microsoft.AspNetCore.Http;

namespace ASM_Auto.Services.Common
{
    public interface IImageService
    {
        public Task<Image> UploadImage(IFormFile imageFile);

        public Task RemoveImages(Guid productId);

    }
}
