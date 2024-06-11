using Microsoft.AspNetCore.Mvc;
using MyWebApp.Services;

namespace MyWebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Controllers : ControllerBase
{
    private readonly IDbService _dbService;
    public Controllers(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("/api/characters/{characterId}")]
    public async Task<IActionResult> GetInfo(int characterId)
    {
        if (!await _dbService.DoesCharacterExist(characterId))
        {
            return NotFound();
        }
        return Ok(await _dbService.GetCharacterInfo(characterId));
    }
    [HttpPost("/api/characters/{characterId}/backpacks")]
    public async Task<IActionResult> PutInfo(List<int> list,int characterId)
    {
        if (!await _dbService.DoesItemsExist(list))
        {
            return NotFound();
        }

        if (await _dbService.AddItems(list,characterId))
        {
            return Ok();
        }
        return BadRequest();
    }

}