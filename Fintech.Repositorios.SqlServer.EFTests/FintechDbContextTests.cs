using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class FintechDbContextTests
    {
        private readonly FintechDbContext dbContext;
        private readonly DbContextOptions<FintechDbContext> dbContextOptions;

        public FintechDbContextTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<FintechDbContext>()
                .UseSqlServer(new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FintechEF;Integrated Security=True"))
                .LogTo(ExibirQuery, LogLevel.Information)
                .Options;

            dbContext = new FintechDbContext(dbContextOptions);
        }

        private void ExibirQuery(string query)
        {
            Console.WriteLine(query);
        }

        [TestMethod()]
        public void InserirClienteTeste()
        {
            var endereco = new Endereco();
            endereco.Cep = "12345000";
            endereco.Cidade = "São Paulo";
            endereco.Logradouro = "R. Tal";
            endereco.Numero = "55";
            endereco.Tipo = TipoEndereco.Residencial;

            var banco = new Banco { Numero = 120, Nome = "Banco Um" };
            var agencia = new Agencia { Banco = banco, Numero = 1121, DigitoVerificador = 1};
            var conta = new ContaCorrente(agencia, 2022, "9");

            var cliente = new Cliente();
            cliente.Cpf = "12345678900";
            cliente.DataNascimento = Convert.ToDateTime("01/01/00");
            
            cliente.Enderecos.Add(endereco);
            cliente.Contas.Add(conta);

            cliente.Nome = "Vítor";
            cliente.Sexo = Sexo.Masculino;

            dbContext.Clientes.Add(cliente);
            dbContext.SaveChanges();
        }
    }
}