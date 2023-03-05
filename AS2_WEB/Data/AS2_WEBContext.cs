using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AS2_WEB.Models;

namespace AS2_WEB.Data
{
    public class AS2_WEBContext : DbContext
    {
        public AS2_WEBContext (DbContextOptions<AS2_WEBContext> options)
            : base(options)
        {
        }

        public DbSet<AS2_WEB.Models.Partner> Partner { get; set; } = default!;

        public DbSet<AS2_WEB.Models.Partnership> Partnership { get; set; } = default!;
    }
}
