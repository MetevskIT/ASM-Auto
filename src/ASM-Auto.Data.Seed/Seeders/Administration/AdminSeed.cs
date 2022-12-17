using ASM_Auto.Data.Models;
using ASM_Auto.Data.Seed.Common;
using ASM_Auto.Services.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.Administration
{
    public class AdminSeed 
    {
        private UserManager<User> userManager;
        private ICartService cartService;
        public AdminSeed(UserManager<User> userManager, ICartService cartService)
        {
            this.userManager = userManager;
            this.cartService = cartService;
        }
        public async Task SeedAsync(ASMAutoDbContext dbContext)
        {
            if (dbContext.Users.Any())
            {
                return;
            }
            var admin = new User
            {
                Email = "admin@gmail.com",
                UserName = "Admin",
            };

            var result = await userManager.CreateAsync(admin, "Admin2003@");

            if (result.Succeeded)
            {

                admin.CartId = await cartService.CreateCart(admin.Id);
                await userManager.UpdateAsync(admin);
                await userManager.AddToRoleAsync(admin, "Administrator");

            }
        }
    }
}
