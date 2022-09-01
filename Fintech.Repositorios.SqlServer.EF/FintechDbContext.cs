using Fintech.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Repositorios.SqlServer.EF
{
    public class FintechDbContext : DbContext
    {
        public FintechDbContext(DbContextOptions<FintechDbContext> opcoes) : base(opcoes)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientes { get; set; } // 1o. - vai dar erro ao tentar instanciar Conta (abstrata), incluir a property abaixo.
        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
    }
}