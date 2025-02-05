using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;

namespace Samurai.DAL.Repositories
{
    public class HorseRepository : ISamurai
    {
        DatabaseContext context { get; set; }
        public HorseRepository(DatabaseContext c)
        {
            context = c;
        }
    }
}