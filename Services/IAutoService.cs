using ApiEfCore.Models;
namespace ApiEfCore.Services;
public interface IAutoService
{
 Task<List<Auto>> GetAllAsync();
 Task<Auto?> GetByIdAsync(int id);
 Task<Auto> CreateAsync(Auto Auto);
 Task<bool> UpdateAsync(int id, Auto Auto);
 Task<bool> DeleteAsync(int id);
}