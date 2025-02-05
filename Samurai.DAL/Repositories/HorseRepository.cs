using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Samurai.DAL.Repositories
{
    public class HorseRepository : ISamurai
    {
        private readonly DatabaseContext context;
        
        public HorseRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task AddHorseAsync(Horse horse)
        {
            await context.Horses.AddAsync(horse);
            await context.SaveChangesAsync();
        }

        public async Task<List<Horse>> GetAllHorsesAsync()
        {
            return await context.Horses.ToListAsync();
        }

        public async Task<Horse?> GetHorseByIdAsync(int id)
        {
            return await context.Horses.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task UpdateHorseAsync(Horse horse)
        {
            context.Horses.Update(horse);
            await context.SaveChangesAsync();
        }
        
        public async Task DeleteHorseAsync(Horse horse)
        {
            context.Horses.Remove(await GetHorseByIdAsync(horse.Id));
            await context.SaveChangesAsync();
        }
    }  
}
