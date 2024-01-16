using System.Globalization;

namespace GerenciadorEstoque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto("TV", 500.00, 10);

            p.Nome = "Televisão 4K";
            p.Nome = "Z";
            Console.WriteLine(p.Nome);
            Console.WriteLine(p.Valor);
        }
    }
}
