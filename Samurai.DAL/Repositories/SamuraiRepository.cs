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

        public void AddSamurai(SamuraiModel samurai)
        {
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        public void DeleteSamurai(int id)
        {
            var samurai = context.Samurais.Find(id);
            context.Samurais.Remove(samurai);
            context.SaveChanges();
        }
    }
}