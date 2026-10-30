using ApiEfCore.Context;
using ApiEfCore.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiEfCore.Services;

public class VehiculoService : IVehiculoService
{
    private readonly miContextDb _dbContext;

    public VehiculoService(miContextDb dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Vehiculo>> GetAllAsync()
    {
        return await _dbContext.vehiculo.ToListAsync();
    }
    public async Task<Vehiculo?> GetByIdAsync(int id)
    {
        return await _dbContext.vehiculo.FindAsync(id);
    }
    public async Task<Vehiculo> CreateAsync(Vehiculo Auto)
    {
        _dbContext.vehiculo.Add(Auto);
        await _dbContext.SaveChangesAsync();
        return Auto;
    }
    public async Task<bool> UpdateAsync(int id, Vehiculo Auto)
    {
        var existing = await _dbContext.vehiculo.FindAsync(id);
        if (existing is null)
        {
            return false;
        }
        existing.Marca = Auto.Marca;
        existing.Modelo = Auto.Modelo;
        existing.Año = Auto.Año;
        existing.Precio = Auto.Precio;
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _dbContext.vehiculo.FindAsync(id);
        if (existing is null)
        {
            return false;
        }
        _dbContext.vehiculo.Remove(existing);
        await _dbContext.SaveChangesAsync();
        return true;
    }

}