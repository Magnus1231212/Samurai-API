using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Repository class for managing Horse entities in the database.
/// </summary>
public class HorseRepository : ISamurai
{
    private readonly DatabaseContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="HorseRepository"/> class.
    /// </summary>
    /// <param name="context">The database context to be used by the repository.</param>
    public HorseRepository(DatabaseContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Adds a new Horse entity to the database asynchronously.
    /// </summary>
    /// <param name="horse">The Horse entity to be added.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddHorseAsync(Horse horse)
    {
        await context.Horses.AddAsync(horse);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves all Horse entities from the database asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of Horse entities.</returns>
    public async Task<List<Horse>> GetAllHorsesAsync()
    {
        return await context.Horses.ToListAsync();
    }

    /// <summary>
    /// Retrieves a Horse entity by its ID from the database asynchronously.
    /// </summary>
    /// <param name="id">The ID of the Horse entity to be retrieved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the Horse entity if found; otherwise, null.</returns>
    public async Task<Horse?> GetHorseByIdAsync(int id)
    {
        return await context.Horses.FirstOrDefaultAsync(h => h.Id == id);
    }

    /// <summary>
    /// Updates an existing Horse entity in the database asynchronously.
    /// </summary>
    /// <param name="horse">The Horse entity to be updated.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task UpdateHorseAsync(Horse horse)
    {
        context.Horses.Update(horse);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes a Horse entity from the database asynchronously.
    /// </summary>
    /// <param name="horse">The Horse entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteHorseAsync(Horse horse)
    {
        context.Horses.Remove(await GetHorseByIdAsync(horse.Id));
        await context.SaveChangesAsync();
    }
}
