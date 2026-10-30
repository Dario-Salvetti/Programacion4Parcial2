using ApiEfCore.Models;
using ApiEfCore.Services;
using Microsoft.AspNetCore.Mvc;
namespace ApiEfCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutosController : ControllerBase
{
    private readonly IVehiculoService _AutoService;
    public AutosController(IVehiculoService AutoService)
    {
        _AutoService = AutoService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Auto>>> GetAll()
    {
        return Ok(await _AutoService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Auto>> GetById(int id)
    {
        var Auto = await _AutoService.GetByIdAsync(id);
        if (Auto is null)
        {
            return NotFound();
        }
        return Ok(Auto);
    }
    [HttpPost]
    public async Task<ActionResult<Auto>> Create(Auto Auto)
    {
        var created = await _AutoService.CreateAsync(Auto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Auto Auto)
    {
        var updated = await _AutoService.UpdateAsync(id, Auto);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _AutoService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
