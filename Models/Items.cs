using System.ComponentModel.DataAnnotations;
namespace ApiEfCore.Models;

public class Item
{   
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string Marca { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? Modelo { get; set; }
    [Range(1950,2026)]
    public int Año { get; set; }
    [DecimalMax.Value(10,2)]
    public decimal Precio { get; set; }
}
