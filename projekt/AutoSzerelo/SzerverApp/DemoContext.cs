using Microsoft.EntityFrameworkCore;
using SzerverApp.Contract;

namespace SzerverApp
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options) : base(options)
        {
            
        }

        //Migrációhoz ide fel kell venni az osztályokat

        public virtual DbSet<Person> People { get; set; } //People tábla felvétele az adatbázisba (reprezentálás)
        
        public virtual DbSet<Item> Item { get; set; } //Item tábla felvétele az adatbázisba (reprezentálás)


        /*
            A Proxies NuGet csomag miatt kell virtual legyen
        */
    }
}
