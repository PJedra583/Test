using Microsoft.EntityFrameworkCore;
using MyWebApp.Context;
using MyWebApp.Models;
using MyWebApp.Models.DTO_s;

namespace MyWebApp.Services;

public class DbService : IDbService
{
    private readonly TestContext _context;
    public DbService(TestContext context)
    {
        _context = context;
    }
    
    public async Task<bool> DoesCharacterExist(int characterId)
    {
        return await _context.characters.AnyAsync(e=>e.Id == characterId);
    }

    public async Task<ExampleDTO> GetCharacterInfo(int characterId)
    {
        var character = await _context.characters
            .Where(e => e.Id == characterId)
            .FirstOrDefaultAsync();
            
            var exampleDTO = new ExampleDTO
            {
                firstName = character.FirstName,
                lastName = character.LastName,
                currentWeight = character.CurrentWeight,
                maxWeight = character.MaxWeight,
                backpackItems = await _context.backpacks
                    .Where(e=>character.Id == characterId)
                    .Select(e=>e.Item)
                    .ToListAsync(),
                titles = await _context.character_titles
                    .Where(e=>e.Character.Id == characterId)
                    .Select(e=> e.Title)
                    .ToListAsync()
            };

            return exampleDTO;
    }

    public async Task<bool> DoesItemsExist(List<int> list)
    {
        foreach (var VARIABLE in list)
        {
            if (!await _context.items.AnyAsync(e => e.Id == VARIABLE))
            {
                return false;
            }
        }
        return true;
    }

    public async Task<bool> AddItems(List<int> list,int characterId)
    {
        var character = await _context.characters
            .Where(e => e.Id == characterId)
            .FirstOrDefaultAsync();
        int capacity = character.MaxWeight;
        int actuall_weight = character.CurrentWeight;
        foreach (var VARIABLE in list)
        {
            Item item = await _context.items.Where(e => e.Id == VARIABLE).FirstOrDefaultAsync();
            if (actuall_weight + item.Weight > capacity)
            {
                return false;
            }
            else
            {
                _context.backpacks.Add(new Backpack()
                {
                    ItemId = item.Id,
                    Amount = 1,
                    CharacterId = characterId
                });
            }
        }

        await _context.SaveChangesAsync();
        return true;
    }
}