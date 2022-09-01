﻿using Fintech.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fintech.Repositorios.SqlServer.EF.ModelConfiguration
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasIndex(c => c.Cpf).IsUnique();

            //builder.HasMany(c => c.Enderecos);

            builder.Property(c => c.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(250);
            builder.Property(c => c.DataNascimento).IsRequired();
            builder.Property(c => c.Sexo).IsRequired();
        }
    }
}