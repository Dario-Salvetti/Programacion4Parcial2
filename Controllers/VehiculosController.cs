using ApiEfCore.Models;
using ApiEfCore.Services;
using Microsoft.AspNetCore.Mvc;
namespace ApiEfCore.Controllers;

using System.Collections.Generic;


[ApiController]
[Route("api/[controller]")]
public class VehiculosController : ControllerBase
{
    private readonly IVehiculoService _VehiculoService;
    public VehiculosController(IVehiculoService VehiculoService)
    {
        _VehiculoService = VehiculoService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Vehiculo>>> GetAll()
    {
        return Ok(await _VehiculoService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehiculo>> GetById(int id)
    {
        var vehiculo = await _VehiculoService.GetByIdAsync(id);
        if (vehiculo is null)
        {
            return NotFound();
        }
        return Ok(vehiculo);
    }

    [HttpGet("tipo/{tipo}")]
    public async Task<ActionResult<List<Vehiculo>>> GetByTipo(TipoVehiculo tipo)
    {
        var vehiculos = await _VehiculoService.GetByTipoAsync(tipo);
        return Ok(vehiculos);
    }
    [HttpPost]
    public async Task<ActionResult<Vehiculo>> Create(Vehiculo vehiculo)
    {
        try
        {
            var created = await _VehiculoService.CreateAsync(vehiculo);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Vehiculo vehiculo)
    {
        var updated = await _VehiculoService.UpdateAsync(id, vehiculo);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _VehiculoService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
