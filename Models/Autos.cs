using System.ComponentModel.DataAnnotations;
namespace ApiEfCore.Models;

public class Auto
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
    [Range(1000000, double.MaxValue)]
    public decimal Precio { get; set; }
}
