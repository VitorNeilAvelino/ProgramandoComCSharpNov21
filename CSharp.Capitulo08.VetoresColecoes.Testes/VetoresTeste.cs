using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp.Capitulo08.VetoresColecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            /*int[]*/ var inteiros = new int[5];

            inteiros[0] = 42;
            inteiros[1] = -5;
            //inteiros[5] = 18;

            var decimais = new decimal[] { 0.4m, -3.8m, 4, 7.6M };

            string[] nomes = { "Vítor", "Avelino" };

            var chars = new[] { 'a', 'b', 'c' };

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"Tamanho do vetor {nameof(decimais)}: {decimais.Length}");
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.4m, -3.8m, 4, 7.6M };

            Array.Resize(ref decimais, 5);

            decimais[4] = 2.3m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 0.4m, -3.8m, 4, 7.6M };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], -3.8m);
        }

        private decimal Media(decimal a, decimal b)
        {
            return (a + b) / 2;
        }

        private decimal Media(params decimal[] valores)
        {
            decimal soma = 0;
            foreach (var valor in valores)
            {
                soma += valor;
            }
            return soma / valores.Length;
        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[] { 0.4m, -3.8m, 4, 7.6M };

            Console.WriteLine(Media(decimais));

            Console.WriteLine(Media(2, -1.8m, 4.5m, 9.15m));
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            var nome = "Vítor";

            Assert.AreEqual(nome[0], 'V');

            foreach (var @char in nome)
            {
                Console.Write(@char);
            }

            //StringBuilder;
        }
    }
}
