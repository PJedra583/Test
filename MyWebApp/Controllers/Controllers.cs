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

    [HttpPost("/api/{bookID}")]
    public async Task<IActionResult> GetBook(int bookID)
    {
        if (await _dbService.DoesBookExist(bookID))
        {
            return Ok(await _dbService.GetBook(bookID));
        }

        return NotFound();
    }
}