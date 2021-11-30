using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new("Dados\\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia();
            agencia.Numero = 2;

            var conta = new ContaCorrente(agencia, 1, "1");

            var movimento = new Movimento(Operacao.Saque, 20);
            movimento.Conta = conta;

            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.Selecionar(2, 1);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data}: {movimento.Operacao} {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void OrderByTeste()
        {
            var movimentos = repositorio.Selecionar(2, 1)
                .OrderBy(m => m.Valor)
                .ThenBy(m => m.Operacao)
                .ThenByDescending(m => m.Data);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data}: {movimento.Operacao} {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void CountTeste()
        {
            var qtdDepositos = repositorio.Selecionar(2, 1)
                .Count(m => m.Operacao == Operacao.Deposito);

            Assert.AreEqual(qtdDepositos, 2);
        }

        [TestMethod]
        public void LikeTeste()
        {
            var movimentos = repositorio.Selecionar(2, 1)
                .Where(m => m.Data.ToString().Contains("29/11/2021"));

            //Assert.IsTrue(movimentos.Count() == 0);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data}: {movimento.Operacao} {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void MinTeste()
        {
            var menorDeposito = repositorio.Selecionar(2, 1)
                .Where(m => m.Operacao == Operacao.Deposito)
                .Min(m => m.Valor);

            Assert.IsTrue(menorDeposito == 10);
        }

        [TestMethod]
        public void SkipTakeTeste()
        {
            var movimentos = repositorio.Selecionar(2, 1)
                .Skip(1)
                .Take(5)
                .ToList();

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data}: {movimento.Operacao} {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void GroupByTeste()
        {
            var agrupamento = repositorio.Selecionar(2, 1)
                //.GroupBy(m => m.Operacao)
                .GroupBy(m => new { m.Operacao, m.Data.Date })
                .Select(g => new { Operacao = g.Key.Operacao, Data = g.Key.Date, Total = g.Sum(m => m.Valor) });

            foreach (var item in agrupamento)
            {
                Console.WriteLine($"{item.Operacao} - {item.Data:d}: {item.Total:c}");
            }
        }
    }
}