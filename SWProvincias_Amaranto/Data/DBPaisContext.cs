using Microsoft.EntityFrameworkCore;
using SWProvincias_Amaranto.Models;

namespace SWProvincias_Amaranto.Data
{
    public class DBPaisContext : DbContext
    {
        //constructor
        public DBPaisContext(DbContextOptions<DBPaisContext> options) : base(options) { }

        //Propiedades
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Provincia> Provincias { get; set; } 

    }
}

