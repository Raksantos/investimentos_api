using Microsoft.EntityFrameworkCore;

namespace MeuProjeto
{
    public class MeuDbContext : DbContext
    {
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Acoes> Acoes { get; set; }

        public DbSet<Cripto> Cripto { get; set; }

        public DbSet<FundoImobiliario> FundoImobiliario { get; set; }

        public DbSet<PrevidenciaPrivada> PrevidenciaPrivada { get; set; }

        public DbSet<RendaFixa> RendaFixa { get; set; }

        public DbSet<TesouroDireto> TesouroDireto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgrespass");
        }
    }

    public class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string SaldoDisponivel { get; set; }
        public string SaldoInvestido { get; set; }
    }

    public class Acoes
    {
        public int Id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public double volume { get; set; }
        public double valor_mercado { get; set; }    
    }

    public class Cripto
    {
        public int Id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public double volume { get; set; }
        public double valor_mercado { get; set; }
    }

    public class FundoImobiliario
    {
        public int Id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public double volume { get; set; }
        public double valor_mercado { get; set; }
    }

    public class PrevidenciaPrivada
    {
        public int Id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public double volume { get; set; }
        public double valor_mercado { get; set; }
    }

    public class RendaFixa
    {
        public int Id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public double volume { get; set; }
        public double valor_mercado { get; set; }
    }

    public class TesouroDireto
    {
        public int Id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public double volume { get; set; }
        public double valor_mercado { get; set; }
    }
}
