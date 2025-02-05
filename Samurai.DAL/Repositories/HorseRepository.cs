using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Samurai.DAL.Repositories
{
    /// <summary>
    /// Repository for handling operations related to the Horse entity.
    /// Provides methods to perform CRUD operations and database queries.
    /// </summary>
    public class HorseRepository : IHorse
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="HorseRepository"/> class.
        /// </summary>
        /// <param name="context">The database context used to interact with the database.</param>
        public HorseRepository(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a new horse to the database.
        /// </summary>
        /// <param name="horse">The horse entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddHorseAsync(Horse horse)
        {
            await context.Horses.AddAsync(horse);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all horses from the database.
        /// </summary>
        /// <returns>A list of all horses.</returns>
        public async Task<List<Horse>> GetAllHorsesAsync()
        {
            return await context.Horses.ToListAsync();
        }

        /// <summary>
        /// Retrieves a horse by its ID.
        /// </summary>
        /// <param name="id">The ID of the horse to retrieve.</param>
        /// <returns>The horse if found; otherwise, null.</returns>
        public async Task<Horse?> GetHorseByIdAsync(int id)
        {
            return await context.Horses.FirstOrDefaultAsync(h => h.Id == id);
        }

        /// <summary>
        /// Updates an existing horse in the database.
        /// </summary>
        /// <param name="horse">The horse entity with updated values.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateHorseAsync(Horse horse)
        {
            context.Horses.Update(horse);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a horse from the database.
        /// </summary>
        /// <param name="horse">The horse entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteHorseAsync(Horse horse)
        {
            context.Horses.Remove(await GetHorseByIdAsync(horse.Id));
            await context.SaveChangesAsync();
        }
    }
}