using ApiEfCore.Models;
using ApiEfCore.Services;
using Microsoft.AspNetCore.Mvc;
namespace ApiEfCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;
    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetAll()
    {
        return Ok(await _itemService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetById(int id)
    {
        var item = await _itemService.GetByIdAsync(id);
        if (item is null)
        {
            return NotFound();
        }
        return Ok(item);
    }
    [HttpPost]
    public async Task<ActionResult<Item>> Create(Item item)
    {
        var created = await _itemService.CreateAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Item item)
    {
        var updated = await _itemService.UpdateAsync(id, item);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _itemService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
