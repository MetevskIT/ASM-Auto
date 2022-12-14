using ASM_Auto.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{

    public interface IUserService
    {
        public Task AddToLikedCollection(Guid productId, string userId);
        public Task RemoveFromLikedCollection(Guid productId, string userId);

        public Task<bool> IsLiked(Guid productId, string userId);

        public Task<List<LikedProductsViewModel>> GetLikedProducts(string userId);

    }
}
