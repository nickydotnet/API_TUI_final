using Microsoft.EntityFrameworkCore;

namespace API_TUI.Model
{
    public class TUI_Context : DbContext
    {
        public TUI_Context(DbContextOptions<TUI_Context> options)
            : base(options)
        {
        }

        public DbSet<Product> ProductItems { get; set; }
    }
}
