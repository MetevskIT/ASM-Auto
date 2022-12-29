using ASM_Auto.Data.Repository;
using ASM_Auto.Services.AutoAccessoriesServices;
using ASM_Auto.Services.AutoCosmetics;
using ASM_Auto.Services.Car;
using ASM_Auto.Services.CartService;
using ASM_Auto.Services.Common;
using ASM_Auto.Services.ImageService;
using ASM_Auto.Services.MultimediaServices;
using ASM_Auto.Services.OrdersServices;
using ASM_Auto.Services.ProductServices;
using ASM_Auto.Services.UserServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Add repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Add Services
            services.AddScoped<ILedlightsService, LedlightsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IMatsService, MatsService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IFoilService, FoilsService>();
            services.AddScoped<IAutoshampooService, AutoshampooService>();
            services.AddScoped<ICleaningAccessoryService, CleaningAccessoryService>();
            services.AddScoped<IMultimediaService, MultimediaService>();
            services.AddScoped<IBackUpCameraService, BackUpCameraService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IImageService, ImageService>();

            return services;
        }
    }
}
