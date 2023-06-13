using Microsoft.EntityFrameworkCore;

namespace SzerverApp
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options) : base(options)
        {
            
        }

        public virtual DbSet<Person> People { get; set; } //Tábla reprezentálása
    }
}
