using Microsoft.EntityFrameworkCore;
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

        public async Task AddSamuraiAsync(SamuraiModel samurai)
        {
            context.Samurais.Add(samurai);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSamuraiAsync(int id)
        {
            var samurai = context.Samurais.Where(s => s.Id == id).FirstOrDefault();
            context.Samurais.Remove(samurai);
            await context.SaveChangesAsync();
        }

        public async Task<SamuraiModel> GetSamuraiAsync(int id)
        {
            return await context.Samurais.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateSamuraiAsync(SamuraiModel samurai)
        {
            context.Samurais.Update(samurai);
            await context.SaveChangesAsync();
        }

        public async Task<List<SamuraiModel>> GetAllSamuraisAsync()
        {
            return await context.Samurais.ToListAsync();
        }

        public async Task<List<SamuraiModel>> GetSamuraisWithHorseAsync()
        {
            return await context.Samurais.Include(s => s.Horse).ToListAsync();
        }

        public async Task<List<SamuraiModel>> GetSamuraisWithBattlesAsync()
        {
            return await context.Samurais.Include(s => s.Battles).ToListAsync();
        }

        public async Task AddBattleToSamuraiAsync(int samuraiId, int battleId)
        {
            var samurai = context.Samurais.Where(s => s.Id == samuraiId).FirstOrDefault();
            var battle = context.Battles.Where(b => b.Id == battleId).FirstOrDefault();
            samurai.Battles.Add(battle);
            await context.SaveChangesAsync();
        }

        public async Task RemoveBattleFromSamuraiAsync(int samuraiId, int battleId)
        {
            var samurai = context.Samurais.Where(s => s.Id == samuraiId).FirstOrDefault();
            var battle = context.Battles.Where(b => b.Id == battleId).FirstOrDefault();
            samurai.Battles.Remove(battle);
            await context.SaveChangesAsync();
        }

        public async Task AddHorseToSamuraiAsync(int samuraiId, int horseId)
        {
            var samurai = context.Samurais.Where(s => s.Id == samuraiId).FirstOrDefault();
            var horse = context.Horses.Where(h => h.Id == horseId).FirstOrDefault();
            samurai.Horse = horse;
            await context.SaveChangesAsync();
        }

        public async Task RemoveHorseFromSamuraiAsync(int samuraiId)
        {
            var samurai = context.Samurais.Where(s => s.Id == samuraiId).FirstOrDefault();
            samurai.Horse = null;
            await context.SaveChangesAsync();
        }
    }
}