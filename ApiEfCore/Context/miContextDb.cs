using Microsoft.EntityFrameworkCore;
using ApiEfCore.Models;
namespace ApiEfCore.Context;

public class miContextDb : DbContext
{
    public DbSet<Item> Items { get; set; }
    public miContextDb(DbContextOptions<miContextDb> options)
    : base(options)
    {
    }
}