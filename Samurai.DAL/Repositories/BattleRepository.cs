using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Samurai.DAL.Repositories
{
    /// <summary>
    /// Repository for handling operations related to the Battle entity.
    /// Provides methods to perform CRUD operations and database queries.
    /// </summary>
    public class BattleRepository : ISamurai
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleRepository"/> class.
        /// </summary>
        /// <param name="c">The database context used to interact with the database.</param>
        public BattleRepository(DatabaseContext c)
        {
            context = c;
        }

        /// <summary>
        /// Retrieves all battles from the database.
        /// </summary>
        /// <returns>A list of all battles.</returns>
        public async Task<List<Battle>> GetAllBattlesAsync()
        {
            return await context.Battles.ToListAsync();
        }

        /// <summary>
        /// Retrieves a battle by its ID.
        /// </summary>
        /// <param name="id">The ID of the battle to retrieve.</param>
        /// <returns>The battle if found; otherwise, null.</returns>
        public async Task<Battle?> GetBattleByIdAsync(int id)
        {
            return await context.Battles.FirstOrDefaultAsync(b => b.Id == id);
        }

        /// <summary>
        /// Adds a new battle to the database.
        /// </summary>
        /// <param name="battle">The battle entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddBattleAsync(Battle battle)
        {
            context.Battles.Add(battle);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing battle in the database.
        /// </summary>
        /// <param name="battle">The battle entity with updated values.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateBattleAsync(Battle battle)
        {
            context.Battles.Update(battle);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a battle from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the battle to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteBattleAsync(int id)
        {
            context.Battles.Remove(await GetBattleByIdAsync(id));
            await context.SaveChangesAsync();
        }
    }
}