using Microsoft.EntityFrameworkCore;
using TestRest.Models;

namespace TestRest.Managers
{
    public class FlowerContext : DbContext
    {
        public FlowerContext(DbContextOptions<FlowerContext> options) 
            : base(options) { }

        public DbSet<Flower> Flowers { get; set; }
    }
}
