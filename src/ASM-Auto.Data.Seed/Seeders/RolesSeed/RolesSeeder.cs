using ASM_Auto.Data.Seed.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Seeders.RolesSeed
{
    public class RolesSeeder
    {
        private RoleManager<IdentityRole> roleManager;
        public RolesSeeder(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task SeedRoles() 
        {
            if (roleManager.Roles.Any())
            {
                return;
            }
            await roleManager.CreateAsync(new IdentityRole { Name = "Administrator" });
            await roleManager.CreateAsync(new IdentityRole { Name = "User" });
        }
    }
}
