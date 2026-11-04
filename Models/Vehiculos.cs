using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiEfCore.Models;
public enum TipoVehiculo{
    Auto,
    Moto
}
public class Vehiculo
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Se requiere una marca")]
    [MaxLength(25)]
    public string Marca { get; set; }
    [MaxLength(100)]
    public string? Modelo { get; set; }
    [Range(1885,2026)]
    public int Año { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public virtual decimal Precio { get; set; }
    public TipoVehiculo TipoVehiculo { get; set; }

}
