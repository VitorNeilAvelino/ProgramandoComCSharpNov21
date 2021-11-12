using System;
using System.Globalization;

namespace CSharp.Capitulo01.ValeTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
            Inicio:

            Console.Write("Funcionário: ");
            var nome = Console.ReadLine()/*.ToString()*/;

            Console.Write("Salário: ");
            var salario = Convert.ToDecimal(Console.ReadLine());
            //decimal salario = decimal.Parse(Console.ReadLine());

            Console.Write("Transporte: ");
            var gastoComTransporte = Convert.ToDecimal(Console.ReadLine());

            //var descontoMaximo = salario * 6 / 100;
            var descontoMaximo = salario * 0.06M;

            var descontoVT = gastoComTransporte > descontoMaximo ? descontoMaximo : gastoComTransporte;

            var resultado = $"\nFuncionário: {nome}\n" +
                //$"Salário: {salario:c}\n" +
                $"Salário: {salario.ToString("C", new CultureInfo("en-US"))}\n" + //pt-BR
                $"Desconto VT: {descontoVT:C}";

            Console.WriteLine(resultado);

            Console.WriteLine("\nPressione Enter para novo cálculo ou Esc para sair.");

            var comando = Console.ReadKey();

            if (comando.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            Console.Clear();

            goto Inicio;
        }
    }
}
