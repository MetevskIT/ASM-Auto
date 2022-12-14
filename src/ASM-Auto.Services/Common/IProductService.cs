using ASM_Auto.Data.Models;
using ASM_Auto.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{
    public interface IProductService
    {
        public Task<Product> GetProductById(Guid productId);

    }
}
