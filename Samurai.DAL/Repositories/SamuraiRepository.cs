using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;

namespace Samurai.DAL.Repositories
{
    public class SamuraiRepository : ISamurai
    {
        DatabaseContext context { get; set; }
        public SamuraiRepository(DatabaseContext c)
        {
            context = c;
        }
    }
}