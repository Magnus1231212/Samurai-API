using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Samurai.DAL.Repositories
{
    public class BattleRepository : ISamurai
    {
        private readonly DatabaseContext context;

        public BattleRepository(DatabaseContext c)
        {
            context = c;
        }

        public async Task<List<Battle>> GetAllBattlesAsync()
        {
            return await context.Battles.ToListAsync();
        }

        public async Task<Battle?> GetBattleByIdAsync(int id)
        {
            return await context.Battles.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddBattleAsync(Battle battle)
        {
            context.Battles.Add(battle);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBattleAsync(Battle battle)
        {
            var existingBattle = await context.Battles.FindAsync(battle.Id);
            if (existingBattle != null)
            {
                existingBattle.Name = battle.Name;
                existingBattle.StartDate = battle.StartDate;
                existingBattle.EndDate = battle.EndDate;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteBattleAsync(int id)
        {
            var battle = await context.Battles.FindAsync(id);
            if (battle != null)
            {
                context.Battles.Remove(battle);
                await context.SaveChangesAsync();
            }
        }
    }
}