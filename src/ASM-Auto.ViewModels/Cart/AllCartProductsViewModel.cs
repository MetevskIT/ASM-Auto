using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.Cart
{
    public class AllCartProductsViewModel
    {
        public List<CartViewModel> Products { get; set; } = new List<CartViewModel>();
    }
}
