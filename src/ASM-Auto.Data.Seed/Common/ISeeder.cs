using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Seed.Common
{
     public interface ISeeder
     { 
        Task SeedAsync(ASMAutoDbContext dbContext);

     }

    
}
