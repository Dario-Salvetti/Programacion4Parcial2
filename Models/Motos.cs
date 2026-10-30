using System.ComponentModel.DataAnnotations;
namespace ApiEfCore.Models;

public class Moto : Vehiculo
{   

    [Range(500000, double.MaxValue)]
    public override decimal Precio { get; set; }
}