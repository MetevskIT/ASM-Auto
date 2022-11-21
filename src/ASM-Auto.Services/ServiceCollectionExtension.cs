using ASM_Auto.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{ 
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Add repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Add Services
            

            return services;
        }
    }
}
