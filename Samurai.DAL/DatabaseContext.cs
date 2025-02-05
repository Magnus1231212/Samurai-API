using Microsoft.EntityFrameworkCore;

namespace DeSejeBanditter.DAL.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Battle> Battles { get; set; }
    }
}
