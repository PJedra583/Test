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
    
    public async Task<bool> DoesBookExist(int bookID)
    {
        return await _context.Books.AnyAsync(e=>e.Id == bookID);
    }

    public async Task<ExampleDTO> GetBook(int bookID)
    {
        return await _context.Books.Include(e => e.Author)
            .Where(e => e.Id == bookID)
            .Select(async e => new ExampleDTO()
            {
                author = e.Author,
                book = await _context.Books.Where(e => e.Id == bookID).FirstOrDefaultAsync()
            }).FirstOrDefault();
    }
}