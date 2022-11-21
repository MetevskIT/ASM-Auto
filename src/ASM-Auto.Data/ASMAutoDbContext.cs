using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data
{
    public class ASMAutoDbContext : IdentityDbContext<IdentityUser<Guid>,IdentityRole<Guid>,Guid>
    {
        public ASMAutoDbContext(DbContextOptions options)
           : base(options)
        {
        }

    }
}
