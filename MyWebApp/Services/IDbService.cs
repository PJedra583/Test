using MyWebApp.Models.DTO_s;

namespace MyWebApp.Services;

public interface IDbService
{
    Task<bool> DoesCharacterExist(int characterId);
    Task<ExampleDTO> GetCharacterInfo(int characterId);
    Task<bool> DoesItemsExist(List<int> list);
    Task<bool> AddItems(List<int> list,int characterId);

}