using ApiEfCore.Models;
namespace ApiEfCore.Services;
public interface IVehiculoService
{
 Task<List<Vehiculo>> GetAllAsync();
 Task<Vehiculo?> GetByIdAsync(int id);
 Task<Vehiculo> CreateAsync(Vehiculo vehiculo);
 Task<bool> UpdateAsync(int id, Vehiculo vehiculo);
 Task<bool> DeleteAsync(int id);
}