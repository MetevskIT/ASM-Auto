using ASM_Auto.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{
    public interface IImageService
    {
        public Task<Image> UploadImage(IFormFile imageFile);
        public Task RemoveImages(Guid productId);
    }
}
