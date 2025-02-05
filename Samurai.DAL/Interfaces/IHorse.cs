using Samurai.DAL.Models;

namespace Samurai.DAL.Interfaces
{
    public interface IHorse
    {
        Task AddHorseAsync(Horse horse);
        Task<List<Horse>> GetAllHorsesAsync();
        Task<Horse?> GetHorseByIdAsync(int id);
        Task UpdateHorseAsync(Horse horse);
        Task DeleteHorseAsync(Horse horse);
    }
}