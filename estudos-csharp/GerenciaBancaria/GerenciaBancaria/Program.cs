using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerenciaBancaria {
    internal class Program {
        static void Main(string[] args) {
            Conta conta;
            Console.Write("Digite o Número da Conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Titutal da conta: ");
            string nome = Console.ReadLine();

            Console.Write("Haverá Depósito Inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if(resp == 's' || resp == 'S') {
                Console.Write("Digite o Valor do Depósito: R$");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new Conta(numero, nome, depositoInicial);
            } else {
                conta = new Conta(numero, nome);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da Conta:");
            Console.WriteLine(conta);
            Console.WriteLine();

            Console.Write("Digite o valor do depósito: ");
            conta.Deposito(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));

            Console.WriteLine();
            Console.WriteLine("Dados da Conta Atualizados:");
            Console.WriteLine(conta);

            Console.Write("Digite o valor do saque: ");
            conta.Saque(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));

            Console.WriteLine();
            Console.WriteLine("Dados da Conta Atualizados:");
            Console.WriteLine(conta);
        }
    }
}
