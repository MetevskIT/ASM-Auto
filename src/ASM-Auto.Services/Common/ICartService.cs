﻿using ASM_Auto.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Services.Common
{
    public interface ICartService
    {
        public Task<Guid> CreateCart(string userId);

        //public Task<List<CartProduct>> GetCartProducts(string userId);
    }
}
