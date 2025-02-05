using Samurai.DAL.Models;

namespace Samurai.DAL.Interfaces
{
    public interface IBattle
    {
        Task<List<Battle>> GetAllBattlesAsync();
        Task<Battle?> GetBattleByIdAsync(int id);
        Task AddBattleAsync(Battle battle);
        Task UpdateBattleAsync(Battle battle);
        Task DeleteBattleAsync(int id);
    }
}