using Microsoft.AspNetCore.Mvc;
using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samurai.API.Controllers
{
    /// <summary>
    /// API Controller for managing Samurai entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SamuraiController : ControllerBase
    {
        private readonly ISamurai _samuraiRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SamuraiController"/> class.
        /// </summary>
        /// <param name="samuraiRepository">The samurai repository instance.</param>
        public SamuraiController(ISamurai samuraiRepository)
        {
            _samuraiRepository = samuraiRepository;
        }

        /// <summary>
        /// Retrieves all samurais.
        /// </summary>
        /// <returns>A list of all samurais.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SamuraiModel>>> GetSamurais()
        {
            var samurais = await _samuraiRepository.GetAllSamuraisAsync();
            return Ok(samurais);
        }

        /// <summary>
        /// Retrieves a specific samurai by ID.
        /// </summary>
        /// <param name="id">The ID of the samurai to retrieve.</param>
        /// <returns>The samurai entity if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SamuraiModel>> GetSamurai(int id)
        {
            var samurai = await _samuraiRepository.GetSamuraiAsync(id);
            if (samurai == null)
            {
                return NotFound();
            }
            return Ok(samurai);
        }

        /// <summary>
        /// Adds a new samurai.
        /// </summary>
        /// <param name="samurai">The samurai entity to add.</param>
        /// <returns>The created samurai entity.</returns>
        [HttpPost]
        public async Task<ActionResult<SamuraiModel>> PostSamurai(SamuraiModel samurai)
        {
            await _samuraiRepository.AddSamuraiAsync(samurai);
            return CreatedAtAction(nameof(GetSamurai), new { id = samurai.Id }, samurai);
        }

        /// <summary>
        /// Updates an existing samurai.
        /// </summary>
        /// <param name="id">The ID of the samurai to update.</param>
        /// <param name="samurai">The updated samurai entity.</param>
        /// <returns>No content if the update is successful; otherwise, BadRequest if the ID does not match.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSamurai(int id, SamuraiModel samurai)
        {
            if (id != samurai.Id)
            {
                return BadRequest();
            }

            await _samuraiRepository.UpdateSamuraiAsync(samurai);
            return NoContent();
        }

        /// <summary>
        /// Deletes a samurai by ID.
        /// </summary>
        /// <param name="id">The ID of the samurai to delete.</param>
        /// <returns>No content if the deletion is successful; otherwise, NotFound if the samurai does not exist.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSamurai(int id)
        {
            var samurai = await _samuraiRepository.GetSamuraiAsync(id);
            if (samurai == null)
            {
                return NotFound();
            }

            await _samuraiRepository.DeleteSamuraiAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Adds a battle to a samurai.
        /// </summary>
        /// <param name="samuraiId">The ID of the samurai.</param>
        /// <param name="battleId">The ID of the battle to add.</param>
        /// <returns>No content if the operation is successful.</returns>
        [HttpPut("addBattle/{samuraiId}/{battleId}")]
        public async Task<IActionResult> AddBattleToSamurai(int samuraiId, int battleId)
        {
            await _samuraiRepository.AddBattleToSamuraiAsync(samuraiId, battleId);
            return NoContent();
        }

        /// <summary>
        /// Removes a battle from a samurai.
        /// </summary>
        /// <param name="samuraiId">The ID of the samurai.</param>
        /// <param name="battleId">The ID of the battle to remove.</param>
        /// <returns>No content if the operation is successful.</returns>
        [HttpDelete("removeBattle/{samuraiId}/{battleId}")]
        public async Task<IActionResult> RemoveBattleFromSamurai(int samuraiId, int battleId)
        {
            await _samuraiRepository.RemoveBattleFromSamuraiAsync(samuraiId, battleId);
            return NoContent();
        }

        /// <summary>
        /// Adds a horse to a samurai.
        /// </summary>
        /// <param name="samuraiId">The ID of the samurai.</param>
        /// <param name="horseId">The ID of the horse to add.</param>
        /// <returns>No content if the operation is successful.</returns>
        [HttpPut("addHorse/{samuraiId}/{horseId}")]
        public async Task<IActionResult> AddHorseToSamurai(int samuraiId, int horseId)
        {
            await _samuraiRepository.AddHorseToSamuraiAsync(samuraiId, horseId);
            return NoContent();
        }

        /// <summary>
        /// Removes the horse from a samurai.
        /// </summary>
        /// <param name="samuraiId">The ID of the samurai.</param>
        /// <returns>No content if the operation is successful.</returns>
        [HttpDelete("removeHorse/{samuraiId}")]
        public async Task<IActionResult> RemoveHorseFromSamurai(int samuraiId)
        {
            await _samuraiRepository.RemoveHorseFromSamuraiAsync(samuraiId);
            return NoContent();
        }
    }
}
