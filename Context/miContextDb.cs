using Microsoft.EntityFrameworkCore;
using ApiEfCore.Models;
namespace ApiEfCore.Context;

public class miContextDb : DbContext
{
    public DbSet<Vehiculo> vehiculo { get; set; }
    public miContextDb(DbContextOptions<miContextDb> options): base(options)
    {
    }
}
