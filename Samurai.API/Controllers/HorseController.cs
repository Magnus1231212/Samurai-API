using Microsoft.AspNetCore.Mvc;
using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;

namespace Samurai.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly IHorse _horseRepository;

        public HorseController(IHorse horseRepository)
        {
            _horseRepository = horseRepository;
        }

        // GET: api/Horse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horse>>> GetHorses()
        {
            var horses = await _horseRepository.GetAllHorsesAsync();
            return Ok(horses);
        }

        // GET: api/Horse/5
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

        // POST: api/Horse
        [HttpPost]
        public async Task<ActionResult<Horse>> PostHorse(Horse horse)
        {
            await _horseRepository.AddHorseAsync(horse);
            return CreatedAtAction(nameof(GetHorse), new { id = horse.Id }, horse);
        }

        // PUT: api/Horse/5
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

        // DELETE: api/Horse/5
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