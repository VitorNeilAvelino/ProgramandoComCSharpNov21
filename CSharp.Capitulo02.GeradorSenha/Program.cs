using System;

namespace CSharp.Capitulo02.GeradorSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            //var quantidadeDigitos = Convert.ToInt32(Console.ReadLine());

            //if (quantidadeDigitos < 4 || quantidadeDigitos > 10 || quantidadeDigitos % 2 != 0)
            //{
            //    Console.WriteLine($"O valor {quantidadeDigitos} é inválido de acordo com as regras.");
            //    Console.ReadKey();
            //    return;
            //}

            int quantidadeDigitos;

            do
            {
                Console.Write("Digite a quantidade de dígitos entre 4 e 10: ");
                quantidadeDigitos = ObterQuantidadeDigitos();
            } while (quantidadeDigitos == 0);

            //var senha = string.Empty;
            //var randomico = new Random();

            //for (int i = 0; i < quantidadeDigitos; i++)
            //{
            //    var digito = randomico.Next(10);
            //    senha += digito;
            //}

            //Console.WriteLine($"Senha gerada: {senha}");
        }

        private static int ObterQuantidadeDigitos()
        {
            int.TryParse(Console.ReadLine(), out int quantidadeDigitos);

            //if (quantidadeDigitos < 4 || quantidadeDigitos > 10 || quantidadeDigitos % 2 != 0)
            if (quantidadeDigitos is < 4 or > 10 || quantidadeDigitos % 2 != 0)
            {
                Console.WriteLine($"O valor {quantidadeDigitos} é inválido de acordo com as regras.");
                quantidadeDigitos = 0;
            }

            return quantidadeDigitos;
        }
    }
}
