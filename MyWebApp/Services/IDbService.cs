using MyWebApp.Models.DTO_s;

namespace MyWebApp.Services;

public interface IDbService
{
    Task<bool> DoesBookExist(int bookID);
    Task<ExampleDTO> GetBook(int bookID);
}