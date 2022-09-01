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

        public DbSet<Symbol> Symbol { get; set; } = default!;
    }
}
