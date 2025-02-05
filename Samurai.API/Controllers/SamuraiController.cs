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

    // GET: api/samurai/GetAllSamurais
    [HttpGet]
    [Route("GetAllSamurais")]
    public IActionResult GetAllSamurais()
    {
        var samurais = _samuraiRepository.GetAllSamuraisAsync();
        return Ok(samurais);
    }

    [HttpGet("{id}")]
    public IActionResult GetSamuraiById(int id)
    {
        // var samurai = _samuraiRepository.GetById(id);
        // if (samurai == null)
        //     return NotFound();

        // return Ok(samurai);
        return null;
    }
}