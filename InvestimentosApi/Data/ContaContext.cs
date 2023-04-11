using Microsoft.EntityFrameworkCore;
using InvestimentosApi.Models;

namespace InvestimentosApi.Data
{
    public class ContaContext : DbContext
    {
        public ContaContext(DbContextOptions<ContaContext> options) : base(options)
        {
            
        }

        public DbSet<Conta> Contas { get; set; }
    }
}