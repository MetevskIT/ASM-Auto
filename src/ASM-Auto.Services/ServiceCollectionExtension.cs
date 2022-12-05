
using ASM_Auto.Data.Repository;
using ASM_Auto.Services.AutoAccessoriesServices;
using ASM_Auto.Services.Common;
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


            return services;
        }
    }
}
