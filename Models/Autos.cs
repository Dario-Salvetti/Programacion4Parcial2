using System.ComponentModel.DataAnnotations;
namespace ApiEfCore.Models;

public class Auto : Vehiculo
{   

    [Range(1000000, double.MaxValue)]
    public override decimal Precio { get; set; }
}
