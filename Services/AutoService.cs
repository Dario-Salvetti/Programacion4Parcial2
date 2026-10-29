using ApiEfCore.Context;
using ApiEfCore.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiEfCore.Services;

public class AutoService : IAutoService
{
    private readonly miContextDb _dbContext;

    public AutoService(miContextDb dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Auto>> GetAllAsync()
    {
        return await _dbContext.Autos.ToListAsync();
    }
    public async Task<Auto?> GetByIdAsync(int id)
    {
        return await _dbContext.Autos.FindAsync(id);
    }
    public async Task<Auto> CreateAsync(Auto Auto)
    {
        _dbContext.Autos.Add(Auto);
        await _dbContext.SaveChangesAsync();
        return Auto;
    }
    public async Task<bool> UpdateAsync(int id, Auto Auto)
    {
        var existing = await _dbContext.Autos.FindAsync(id);
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
        var existing = await _dbContext.Autos.FindAsync(id);
        if (existing is null)
        {
            return false;
        }
        _dbContext.Autos.Remove(existing);
        await _dbContext.SaveChangesAsync();
        return true;
    }

}