using Samurai.DAL.Models;

namespace Samurai.DAL.Interfaces
{
    public interface ISamurai
    {
        Task AddSamuraiAsync(SamuraiModel samurai);
        Task DeleteSamuraiAsync(int id);
        Task<SamuraiModel> GetSamuraiAsync(int id);
        Task<List<SamuraiModel>> GetAllSamuraisAsync();
        Task UpdateSamuraiAsync(SamuraiModel samurai);
        Task<List<SamuraiModel>> GetSamuraisWithHorseAsync();
        Task<List<SamuraiModel>> GetSamuraisWithBattlesAsync();
        Task AddBattleToSamuraiAsync(int samuraiId, int battleId);
        Task RemoveBattleFromSamuraiAsync(int samuraiId, int battleId);
        Task AddHorseToSamuraiAsync(int samuraiId, int horseId);
        Task RemoveHorseFromSamuraiAsync(int samuraiId);
    }
}