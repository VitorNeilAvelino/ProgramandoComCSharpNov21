using Fintech.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fintech.Repositorios.SqlServer.EF.ModelConfiguration
{
    internal class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");

            //builder.HasOne(c => c.Cliente);

            builder.Property(c => c.DigitoVerificador).IsRequired().HasMaxLength(1);
            builder.Property(c => c.Numero).IsRequired();
        }
    }
}