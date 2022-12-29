using ASM_Auto.ViewModels.User;

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
