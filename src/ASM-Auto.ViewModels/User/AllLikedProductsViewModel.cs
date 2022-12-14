using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.ViewModels.User
{
    public class AllLikedProductsViewModel
    {
        public List<LikedProductsViewModel> LikedProducts { get; set; } = new List<LikedProductsViewModel>();
    }
}
