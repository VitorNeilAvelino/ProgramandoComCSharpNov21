using Fintech.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fintech.Repositorios.SqlServer.EF.ModelConfiguration
{
    internal class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");            

            builder.Property(e=> e.Cep).IsRequired().HasMaxLength(8);
            builder.Property(e=> e.Cidade).IsRequired().HasMaxLength(50);
            builder.Property(e=> e.Logradouro).IsRequired().HasMaxLength(100);
            builder.Property(e=> e.Numero).IsRequired().HasMaxLength(50);
            builder.Property(e=> e.Tipo).IsRequired();
        }
    }
}