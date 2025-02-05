using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;

namespace Samurai.DAL.Repositories
{
    public class BattleRepository : ISamurai
    {
        DatabaseContext context { get; set; }
        public BattleRepository(DatabaseContext c)
        {
            context = c;
        }
    }
}