using Microsoft.AspNetCore.Mvc;
using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samurai.API.Controllers
{
    /// <summary>
    /// API Controller for managing Horse entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly IHorse _horseRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HorseController"/> class.
        /// </summary>
        /// <param name="horseRepository">The horse repository instance.</param>
        public HorseController(IHorse horseRepository)
        {
            _horseRepository = horseRepository;
        }

        /// <summary>
        /// Retrieves all horses.
        /// </summary>
        /// <returns>A list of all horses.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horse>>> GetHorses()
        {
            var horses = await _horseRepository.GetAllHorsesAsync();
            return Ok(horses);
        }

        /// <summary>
        /// Retrieves a specific horse by ID.
        /// </summary>
        /// <param name="id">The ID of the horse to retrieve.</param>
        /// <returns>The horse entity if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Horse>> GetHorse(int id)
        {
            var horse = await _horseRepository.GetHorseByIdAsync(id);
            if (horse == null)
            {
                return NotFound();
            }
            return Ok(horse);
        }

        /// <summary>
        /// Adds a new horse.
        /// </summary>
        /// <param name="horse">The horse entity to add.</param>
        /// <returns>The created horse entity.</returns>
        [HttpPost]
        public async Task<ActionResult<Horse>> PostHorse(Horse horse)
        {
            await _horseRepository.AddHorseAsync(horse);
            return CreatedAtAction(nameof(GetHorse), new { id = horse.Id }, horse);
        }

        /// <summary>
        /// Updates an existing horse.
        /// </summary>
        /// <param name="id">The ID of the horse to update.</param>
        /// <param name="horse">The updated horse entity.</param>
        /// <returns>No content if the update is successful; otherwise, BadRequest if the ID does not match.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorse(int id, Horse horse)
        {
            if (id != horse.Id)
            {
                return BadRequest();
            }

            await _horseRepository.UpdateHorseAsync(horse);
            return NoContent();
        }

        /// <summary>
        /// Deletes a horse by ID.
        /// </summary>
        /// <param name="id">The ID of the horse to delete.</param>
        /// <returns>No content if the deletion is successful; otherwise, NotFound if the horse does not exist.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorse(int id)
        {
            var horse = await _horseRepository.GetHorseByIdAsync(id);
            if (horse == null)
            {
                return NotFound();
            }

            await _horseRepository.DeleteHorseAsync(horse);
            return NoContent();
        }
    }
}