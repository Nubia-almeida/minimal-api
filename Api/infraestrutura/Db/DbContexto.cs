
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using Microsoft.Extensions.Configuration;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    
    public DbContexto(DbContextOptions<DbContexto> options)
        : base(options)
    {
    }

    public DbSet<Administrador> Administradores { get; set; } = default!;
    public DbSet<Veiculo> Veiculos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #if !DEBUG
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            }
        );
        #endif
    }
    
}