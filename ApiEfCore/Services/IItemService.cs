using ApiEfCore.Models;
namespace ApiEfCore.Services;
public interface IItemService
{
 Task<List<Item>> GetAllAsync();
 Task<Item?> GetByIdAsync(int id);
 Task<Item> CreateAsync(Item item);
 Task<bool> UpdateAsync(int id, Item item);
 Task<bool> DeleteAsync(int id);
}