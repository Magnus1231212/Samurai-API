using Microsoft.AspNetCore.Mvc;
using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;

[ApiController]
[Route("api/[controller]")]
public class SamuraiController : ControllerBase
{
    private readonly ISamurai _samuraiRepository;

    public SamuraiController(ISamurai samuraiRepository)
    {
        _samuraiRepository = samuraiRepository;
    }

    // GET: api/Samurai
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SamuraiModel>>> GetSamurais()
    {
        var samurais = await _samuraiRepository.GetAllSamuraisAsync();
        return Ok(samurais);
    }

    // GET: api/Samurai/5
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

    // POST: api/Samurai
    [HttpPost]
    public async Task<ActionResult<SamuraiModel>> PostSamurai(SamuraiModel samurai)
    {
        await _samuraiRepository.AddSamuraiAsync(samurai);
        return CreatedAtAction(nameof(GetSamurai), new { id = samurai.Id }, samurai);
    }

    // PUT: api/Samurai/5
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

    // DELETE: api/Samurai/5
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

    // PUT: api/Samurai/addBattle/5/1
    [HttpPut("addBattle/{samuraiId}/{battleId}")]
    public async Task<IActionResult> AddBattleToSamurai(int samuraiId, int battleId)
    {
        await _samuraiRepository.AddBattleToSamuraiAsync(samuraiId, battleId);
        return NoContent();
    }

    // DELETE: api/Samurai/removeBattle/5/1
    [HttpDelete("removeBattle/{samuraiId}/{battleId}")]
    public async Task<IActionResult> RemoveBattleFromSamurai(int samuraiId, int battleId)
    {
        await _samuraiRepository.RemoveBattleFromSamuraiAsync(samuraiId, battleId);
        return NoContent();
    }

    // PUT: api/Samurai/addHorse/5/1
    [HttpPut("addHorse/{samuraiId}/{horseId}")]
    public async Task<IActionResult> AddHorseToSamurai(int samuraiId, int horseId)
    {
        await _samuraiRepository.AddHorseToSamuraiAsync(samuraiId, horseId);
        return NoContent();
    }

    // DELETE: api/Samurai/removeHorse/5/
    [HttpDelete("removeHorse/{samuraiId}")]
    public async Task<IActionResult> RemoveHorseFromSamurai(int samuraiId)
    {
        await _samuraiRepository.RemoveHorseFromSamuraiAsync(samuraiId);
        return NoContent();
    }
}