using Microsoft.EntityFrameworkCore;
using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;

namespace Samurai.DAL.Repositories
{
    /// <summary>
    /// Repository for handling CRUD operations and relationships for Samurai entities.
    /// </summary>
    public class SamuraiRepository : ISamurai
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SamuraiRepository"/> class.
        /// </summary>
        /// <param name="c">The database context used for interacting with the database.</param>
        public SamuraiRepository(DatabaseContext c)
        {
            context = c;
        }

        /// <summary>
        /// Adds a new samurai to the database.
        /// </summary>
        /// <param name="samurai">The samurai entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddSamuraiAsync(SamuraiModel samurai)
        {
            context.Samurais.Add(samurai);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a samurai by its ID.
        /// </summary>
        /// <param name="id">The ID of the samurai to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteSamuraiAsync(int id)
        {
            var samurai = await context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (samurai != null)
            {
                context.Samurais.Remove(samurai);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retrieves a samurai by its ID.
        /// </summary>
        /// <param name="id">The ID of the samurai.</param>
        /// <returns>The samurai entity if found; otherwise, null.</returns>
        public async Task<SamuraiModel> GetSamuraiAsync(int id)
        {
            return await context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Updates an existing samurai.
        /// </summary>
        /// <param name="samurai">The samurai entity with updated information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateSamuraiAsync(SamuraiModel samurai)
        {
            context.Samurais.Update(samurai);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all samurais from the database.
        /// </summary>
        /// <returns>A list of all samurais.</returns>
        public async Task<List<SamuraiModel>> GetAllSamuraisAsync()
        {
            return await context.Samurais.ToListAsync();
        }

        /// <summary>
        /// Retrieves all samurais with their associated horse.
        /// </summary>
        /// <returns>A list of samurais with their horse.</returns>
        public async Task<List<SamuraiModel>> GetSamuraisWithHorseAsync()
        {
            return await context.Samurais.Include(s => s.Horse).ToListAsync();
        }

        /// <summary>
        /// Retrieves all samurais with their associated battles.
        /// </summary>
        /// <returns>A list of samurais with their battles.</returns>
        public async Task<List<SamuraiModel>> GetSamuraisWithBattlesAsync()
        {
            return await context.Samurais.Include(s => s.Battles).ToListAsync();
        }

        /// <summary>
        /// Adds a battle to a samurai.
        /// </summary>
        /// <param name="samuraiId">The ID of the samurai.</param>
        /// <param name="battleId">The ID of the battle.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddBattleToSamuraiAsync(int samuraiId, int battleId)
        {
            var samurai = await context.Samurais.FindAsync(samuraiId);
            var battle = await context.Battles.FindAsync(battleId);

            if (samurai != null && battle != null)
            {
                samurai.Battles.Add(battle);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Removes a battle from a samurai.
        /// </summary>
        /// <param name="samuraiId">The ID of the samurai.</param>
        /// <param name="battleId">The ID of the battle to remove.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RemoveBattleFromSamuraiAsync(int samuraiId, int battleId)
        {
            var samurai = await context.Samurais.Include(s => s.Battles)
                                                 .FirstOrDefaultAsync(s => s.Id == samuraiId);
            var battle = await context.Battles.FindAsync(battleId);

            if (samurai != null && battle != null)
            {
                samurai.Battles.Remove(battle);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adds a horse to a samurai.
        /// </summary>
        /// <param name="samuraiId">The ID of the samurai.</param>
        /// <param name="horseId">The ID of the horse.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddHorseToSamuraiAsync(int samuraiId, int horseId)
        {
            var samurai = await context.Samurais.FindAsync(samuraiId);
            var horse = await context.Horses.FindAsync(horseId);

            if (samurai != null && horse != null)
            {
                samurai.Horse = horse;
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Removes the horse from a samurai.
        /// </summary>
        /// <param name="samuraiId">The ID of the samurai.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RemoveHorseFromSamuraiAsync(int samuraiId)
        {
            var samurai = await context.Samurais.FindAsync(samuraiId);
            if (samurai != null)
            {
                samurai.Horse = null;
                await context.SaveChangesAsync();
            }
        }
    }
}