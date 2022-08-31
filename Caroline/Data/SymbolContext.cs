using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Caroline.Models;

namespace Caroline.Data
{
    public class SymbolContext : DbContext
    {
        public SymbolContext (DbContextOptions<SymbolContext> options)
            : base(options)
        {
        }

        public DbSet<Caroline.Models.Symbol> Symbol { get; set; } = default!;
    }
}
