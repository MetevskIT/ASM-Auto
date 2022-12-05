using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{

    public interface IUserService
    {
        public Task AddToCart(Guid productId, string userId);
    }
}
