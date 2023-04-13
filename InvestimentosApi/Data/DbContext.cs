using Microsoft.EntityFrameworkCore;
using InvestimentosApi.Models;

namespace InvestimentosApi.Data;

public class DatabaseCotext : DbContext
{
    public DatabaseCotext(DbContextOptions<DatabaseCotext> options) : base(options)
    {
        
    }

    public DbSet<Conta> Contas { get; set; }
    public DbSet<Cripto> Criptos { get; set; }
    public DbSet<Acoes> Acoes { get; set; }
    public DbSet<FundoImobiliario> FundosImobiliarios { get; set; }
    public DbSet<TesouroDireto> TesouroDiretos { get; set; }
}