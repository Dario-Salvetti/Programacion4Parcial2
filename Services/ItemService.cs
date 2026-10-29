using ApiEfCore.Context;
using ApiEfCore.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiEfCore.Services;

public class ItemService : IItemService
{
    private readonly miContextDb _dbContext;

    public ItemService(miContextDb dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Item>> GetAllAsync()
    {
        return await _dbContext.Items.ToListAsync();
    }
    public async Task<Item?> GetByIdAsync(int id)
    {
        return await _dbContext.Items.FindAsync(id);
    }
    public async Task<Item> CreateAsync(Item item)
    {
        _dbContext.Items.Add(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }
    public async Task<bool> UpdateAsync(int id, Item item)
    {
        var existing = await _dbContext.Items.FindAsync(id);
        if (existing is null)
        {
            return false;
        }
        existing.Name = item.Name;
        existing.Description = item.Description;
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _dbContext.Items.FindAsync(id);
        if (existing is null)
        {
            return false;
        }
        _dbContext.Items.Remove(existing);
        await _dbContext.SaveChangesAsync();
        return true;
    }

}