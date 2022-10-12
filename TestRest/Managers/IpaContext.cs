using Microsoft.EntityFrameworkCore;
using TestRest.Models;

namespace TestRest.Managers
{
    public class IpaContext : DbContext
    {
        public IpaContext(DbContextOptions<IpaContext> options) 
            : base(options) { }

        public DbSet<IPA> IPAs { get; set; }
    }
}
