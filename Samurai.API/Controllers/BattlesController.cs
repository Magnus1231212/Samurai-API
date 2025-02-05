using Microsoft.AspNetCore.Mvc;
using Samurai.DAL.Models;
using Samurai.DAL.Interfaces;


namespace Samurai.API.Controllers
{
    /// <summary>
    /// API Controller for managing battles.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        private readonly IBattle _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattlesController"/> class.
        /// </summary>
        /// <param name="context">The battle repository instance.</param>
        public BattlesController(IBattle context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all battles.
        /// </summary>
        /// <returns>A list of battles.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battle>>> GetBattles()
        {
            var battles = await _context.GetAllBattlesAsync();
            return Ok(battles);
        }

        /// <summary>
        /// Retrieves a battle by ID.
        /// </summary>
        /// <param name="id">The battle ID.</param>
        /// <returns>The battle entity.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Battle>> GetBattle(int id)
        {
            var battle = await _context.GetBattleByIdAsync(id);
            if (battle == null)
            {
                return NotFound();
            }
            return Ok(battle);
        }

        /// <summary>
        /// Adds a new battle.
        /// </summary>
        /// <param name="battle">The battle object to add.</param>
        /// <returns>The created battle.</returns>
        [HttpPost]
        public async Task<ActionResult<Battle>> PostBattle(Battle battle)
        {
            await _context.AddBattleAsync(battle);
            return CreatedAtAction(nameof(GetBattle), new { id = battle.Id }, battle);
        }

        /// <summary>
        /// Updates an existing battle.
        /// </summary>
        /// <param name="id">The ID of the battle.</param>
        /// <param name="battle">The updated battle data.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattle(int id, Battle battle)
        {
            if (id != battle.Id)
            {
                return BadRequest();
            }
            await _context.UpdateBattleAsync(battle);
            return NoContent();
        }

        /// <summary>
        /// Deletes a battle by ID.
        /// </summary>
        /// <param name="id">The ID of the battle to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBattle(int id)
        {
            var battle = await _context.GetBattleByIdAsync(id);
            if (battle == null)
            {
                return NotFound();
            }

            await _context.DeleteBattleAsync(id);
            return NoContent();
        }
    }
}
