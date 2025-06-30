using Microsoft.EntityFrameworkCore;
using APICatalago.Models;


namespace APICatalago.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<categoria>? Categorias { get; set; }
    public DbSet<produto>? Produtos { get; set; }
}
